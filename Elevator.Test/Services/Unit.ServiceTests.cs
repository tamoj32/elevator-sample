using Elevator.Domain.Entities;
using Elevator.Domain.Interfaces;
using Elevator.Infrastructure.DependencyResolution;
using Elevator.Service.Interfaces;
using Elevator.Services.Implementations;
using Elevator.Test.DependencyResolution;
using NUnit.Framework;
using Ninject;

namespace Elevator.Test.Services
{
    [TestFixture]
    public class ElevatorManagerServiceTests
    {
        private IKernel _kernel;

        public ElevatorManagerServiceTests()
        {

        }

        [Test]
        public void GetClosestElevatorTestWhenAllElevatorIdleAndGoDestination()
        {
            _kernel = new StandardKernel(new LoggingModule(), new TestRepositoryModule());
            _kernel.Bind<IElevatorManagerService>().To<ElevatorManagerService>();

            var floorRep = _kernel.Get<IFloorRepository>();
            var floor8 = floorRep.Get(8);
            floor8.DestinationFloor = 3;
            floor8.TotalPeople = 6;

            var elevatorManagerService = _kernel.Get<IElevatorManagerService>();
            elevatorManagerService.WaitTime = 0;
            elevatorManagerService.Operate(floor8);

            var elevatorRep = _kernel.Get<IElevatorRepository>();
            var elevator1 = elevatorRep.Get(1);
            var elevator2 = elevatorRep.Get(2);
            var elevator3 = elevatorRep.Get(3);
            var elevator4 = elevatorRep.Get(4);
            Assert.AreEqual(elevator1.CurrentFloor, 3);
            Assert.AreEqual(elevator2.CurrentFloor, 1);
            Assert.AreEqual(elevator3.CurrentFloor, 1);
            Assert.AreEqual(elevator4.CurrentFloor, 1);
        }

        [Test]
        public void GetClosestElevatorTestWhenOneElevatorCloseThanTheRestAndGoDestination()
        {
            _kernel = new StandardKernel(new LoggingModule(), new TestRepositoryModule());
            _kernel.Bind<IElevatorManagerService>().To<ElevatorManagerService>();

            var elevatorRep = _kernel.Get<IElevatorRepository>();
            var elevatorD = elevatorRep.Get(4);
            elevatorD.CurrentFloor = 10;
            elevatorD.Direction = Direction.Idle;

            var floorRep = _kernel.Get<IFloorRepository>();
            var floor8 = floorRep.Get(8);
            floor8.DestinationFloor = 3;
            floor8.TotalPeople = 6;

            var elevatorManagerService = _kernel.Get<IElevatorManagerService>();
            elevatorManagerService.WaitTime = 0;
            elevatorManagerService.Operate(floor8);

            var elevatorA = elevatorRep.Get(1);
            var elevatorB = elevatorRep.Get(2);
            var elevatorC = elevatorRep.Get(3);

            Assert.AreEqual(elevatorD.CurrentFloor, 3);
            Assert.AreEqual(elevatorA.CurrentFloor, 1);
            Assert.AreEqual(elevatorB.CurrentFloor, 1);
            Assert.AreEqual(elevatorC.CurrentFloor, 1);

        }

    }
}
