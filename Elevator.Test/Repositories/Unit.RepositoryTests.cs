using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elevator.Domain.Entities;
using Elevator.Domain.Interfaces;
using Elevator.Test.DependencyResolution;
using NUnit.Framework;
using Ninject;

namespace Elevator.Test.Repositories
{
    [TestFixture]
    public class RepositoryTests
    {
        private IKernel _ninjectKernel;

        public RepositoryTests()
        {
            _ninjectKernel = new StandardKernel
                (
                    new TestRepositoryModule()
                );
        }

        [Test]
        public void ShouldGetAllElevators()
        {
            // Arrange
            var elevatorRep = _ninjectKernel.Get<IElevatorRepository>();

            // Act
            var elevators = elevatorRep.AllList();

            // Assert
            Assert.That(elevators != null);
            Assert.That(elevators.Count() == 4);
        }

        [Test]
        public void ShouldGetAllFloor()
        {
            // Arrange
            var floorRepository = _ninjectKernel.Get<IFloorRepository>();

            // Act
            var floors = floorRepository.AllList();

            // Assert
            Assert.That(floors != null);
            Assert.AreEqual(floors.Count(), 10);
        }
    }
}
