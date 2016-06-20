using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Elevator.Domain.Entities;
using Elevator.Domain.Interfaces;
using Moq;
using Ninject.Modules;
using Elevator = Elevator.Domain.Entities.Elevator;

namespace Elevator.Test.DependencyResolution
{
    public class TestRepositoryModule : NinjectModule
    {
        public override void Load()
        {
            var elevators = new List<Domain.Entities.Elevator>
                            {
                                new Domain.Entities.Elevator() {ElevatorId = 1, Name = "Elevator A", CurrentFloor = 1, Direction = Direction.Idle},
                                new Domain.Entities.Elevator() {ElevatorId = 2, Name = "Elevator B", CurrentFloor = 1, Direction = Direction.Idle},
                                new Domain.Entities.Elevator() {ElevatorId = 3, Name = "Elevator C", CurrentFloor = 1, Direction = Direction.Idle},
                                new Domain.Entities.Elevator() {ElevatorId = 4, Name = "Elevator D", CurrentFloor = 1, Direction = Direction.Idle}

                            };

            var floors = new List<Floor>
                            {
                                new Floor() {CurrentFloor = 1, DestinationFloor = 0, TotalPeople = 0},
                                new Floor() {CurrentFloor = 2, DestinationFloor = 0, TotalPeople = 0},
                                new Floor() {CurrentFloor = 3, DestinationFloor = 0, TotalPeople = 0},
                                new Floor() {CurrentFloor = 4, DestinationFloor = 0, TotalPeople = 0},
                                new Floor() {CurrentFloor = 5, DestinationFloor = 0, TotalPeople = 0},
                                new Floor() {CurrentFloor = 6, DestinationFloor = 0, TotalPeople = 0},
                                new Floor() {CurrentFloor = 7, DestinationFloor = 0, TotalPeople = 0},
                                new Floor() {CurrentFloor = 8, DestinationFloor = 0, TotalPeople = 0},
                                new Floor() {CurrentFloor = 9, DestinationFloor = 0, TotalPeople = 0},
                                new Floor() {CurrentFloor = 10, DestinationFloor = 0, TotalPeople = 0},
                            };

            var mockElevatorRep = new Mock<IElevatorRepository>();
            mockElevatorRep.Setup(m => m.AllList()).Returns(elevators);
            mockElevatorRep.Setup(m => m.Get(1)).Returns(elevators.Single(s => s.ElevatorId == 1));
            mockElevatorRep.Setup(m => m.Get(2)).Returns(elevators.Single(s => s.ElevatorId == 2));
            mockElevatorRep.Setup(m => m.Get(3)).Returns(elevators.Single(s => s.ElevatorId == 3));
            mockElevatorRep.Setup(m => m.Get(4)).Returns(elevators.Single(s => s.ElevatorId == 4));
            mockElevatorRep.Setup(m => m.AllList(It.IsAny<Expression<Func<Domain.Entities.Elevator, bool>>>()))
                           .Returns((Expression<Func<Domain.Entities.Elevator, bool>> predicate) => elevators);

            mockElevatorRep.Setup(m => m.Update(It.IsAny<Domain.Entities.Elevator>())).Callback((
                Domain.Entities.Elevator elevator) =>
                {
                    var currentElevator = elevators.Single(s => s.ElevatorId == elevator.ElevatorId);
                    currentElevator.CurrentFloor = elevator.CurrentFloor;
                    currentElevator.Direction = elevator.Direction;
                    currentElevator.TotalPeople = elevator.TotalPeople;
                });
            Kernel.Bind<IElevatorRepository>().ToConstant(mockElevatorRep.Object);

            var mockFloorRep = new Mock<IFloorRepository>();
            mockFloorRep.Setup(m => m.AllList()).Returns(floors);
            mockFloorRep.Setup(m => m.Get(1)).Returns(floors.Single(s => s.CurrentFloor == 1));
            mockFloorRep.Setup(m => m.Get(2)).Returns(floors.Single(s => s.CurrentFloor == 2));
            mockFloorRep.Setup(m => m.Get(3)).Returns(floors.Single(s => s.CurrentFloor == 3));
            mockFloorRep.Setup(m => m.Get(4)).Returns(floors.Single(s => s.CurrentFloor == 4));
            mockFloorRep.Setup(m => m.Get(5)).Returns(floors.Single(s => s.CurrentFloor == 5));
            mockFloorRep.Setup(m => m.Get(6)).Returns(floors.Single(s => s.CurrentFloor == 6));
            mockFloorRep.Setup(m => m.Get(7)).Returns(floors.Single(s => s.CurrentFloor == 7));
            mockFloorRep.Setup(m => m.Get(8)).Returns(floors.Single(s => s.CurrentFloor == 8));
            mockFloorRep.Setup(m => m.Get(9)).Returns(floors.Single(s => s.CurrentFloor == 9));
            mockFloorRep.Setup(m => m.Get(10)).Returns(floors.Single(s => s.CurrentFloor == 10));

            mockFloorRep.Setup(m => m.Update(It.IsAny<Floor>())).Callback((
                Floor floor) =>
            {
                var currentFloor = floors.Single(s => s.CurrentFloor == floor.CurrentFloor);
                currentFloor.CurrentFloor = floor.CurrentFloor;
                currentFloor.DestinationFloor = floor.DestinationFloor;
                currentFloor.TotalPeople = floor.TotalPeople;
            });

            Kernel.Bind<IFloorRepository>().ToConstant(mockFloorRep.Object);
        }
    }
}
