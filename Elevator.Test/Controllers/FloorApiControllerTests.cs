using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Elevator.Domain.Entities;
using Elevator.Domain.Interfaces;
using Elevator.Infrastructure.DependencyResolution;
using Elevator.Service.Interfaces;
using Elevator.Services.Implementations;
using Elevator.Test.DependencyResolution;
using Elevator.Web.Controllers;
using NUnit.Framework;
using Ninject;

namespace Elevator.Test.Controllers
{
    public class FloorApiControllerTests
    {
        private IKernel _kernel;

        public FloorApiControllerTests()
        {
            _kernel = new StandardKernel(
                new LoggingModule(),
                new TestRepositoryModule()
                );

            _kernel.Bind<IElevatorManagerService>().To<ElevatorManagerService>();
        }

        [Test]
        public void FloorApiControllerShouldReturnAllFloorModel()
        {
            // Arrange
            var controller = _kernel.Get<FloorApiController>();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var result = controller.Get();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Count, 10);

        }

        [Test]
        public void FloorApiControllerShouldUpdateFloor()
        {
            // Arrange
            var controller = _kernel.Get<FloorApiController>();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var floor = new Floor {CurrentFloor = 8, DestinationFloor = 9, TotalPeople = 19};
            // Act
            var result = controller.Update(floor);

            // Assert
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

        }

        [Test]
        public void FloorApiControllerShouldNotUpdateFloorInvalidPeople()
        {
            // Arrange
            var controller = _kernel.Get<FloorApiController>();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var floor = new Floor { CurrentFloor = 8, DestinationFloor = 9, TotalPeople = 21 };
            // Act
            var result = controller.Update(floor);

            // Assert
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
        }

        [Test]
        public void FloorApiControllerShouldNotUpdateFloorInvalidFloor()
        {
            // Arrange
            var controller = _kernel.Get<FloorApiController>();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var floor = new Floor { CurrentFloor = 8, DestinationFloor = 9, TotalPeople = 21 };
            // Act
            var result = controller.Update(floor);

            // Assert
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);

        }


    }
}
