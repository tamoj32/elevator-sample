using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Elevator.Infrastructure.DependencyResolution;
using Elevator.Test.DependencyResolution;
using Elevator.Web.Controllers;
using NUnit.Framework;
using Ninject;

namespace Elevator.Test.Controllers
{
    public class ElevatorApiControllerTests
    {
        private IKernel _kernel;

        public ElevatorApiControllerTests()
        {
            _kernel = new StandardKernel(
                new LoggingModule(),
                new TestRepositoryModule()
                );

        }

        [Test]
        public void ElevatorApiControllerShouldReturnAllElevators()
        {
            // Arrange
            var controller = _kernel.Get<ElevatorApiController>();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var result = controller.Get();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Count, 4);

        }

    }
}
