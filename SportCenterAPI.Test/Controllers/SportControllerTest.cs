using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportCenterAPI.Models;
using SportCenterAPI.Models.Manager;

namespace SportCenterAPI.Controllers.Test
{
    [TestClass]
    public class SportControllerTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var manager = new Mock<ISportManager>();
            var controller = new SportsController(manager.Object);

            controller.Should().NotBeNull();
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetSportsTestAsync()
        {
            var manager = new Mock<ISportManager>();

            manager.Setup(m => m.GetAll())
                .ReturnsAsync(new List<Sport>() { new Sport() { Id = 11} });

            var controller = new SportsController(manager.Object);
            var actionResult = await controller.GetSports();

            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<ActionResult<IEnumerable<Sport>>>();

            // Checks the 200 response
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            var result = actionResult.Result as OkObjectResult;

            //Checks the content of the response
            var responseValue = result.Value as IEnumerable<Sport>;
            responseValue.Count().Should().Be(1);
            responseValue.ElementAt(0).Id.Should().Be(11);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetSportTestAsync()
        {
            var manager = new Mock<ISportManager>();

            manager.Setup(m => m.Get(11))
                .ReturnsAsync(new Sport() { Id = 11 });

            var controller = new SportsController(manager.Object);
            var actionResult = await controller.GetSport(11);

            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<ActionResult<Sport>>();

            // Checks the 200 response
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            var result = actionResult.Result as OkObjectResult;

            //Checks the content of the response
            var responseValue = result.Value as Sport;
            responseValue.Id.Should().Be(11);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetSportNotFoundTestAsync()
        {
            var manager = new Mock<ISportManager>();
            Sport s = null;

            manager.Setup(m => m.Get(11))
                .ReturnsAsync(s);

            var controller = new SportsController(manager.Object);
            var actionResult = await controller.GetSport(11);

            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<ActionResult<Sport>>();

            // Checks the 404 response
            actionResult.Result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public async System.Threading.Tasks.Task PutSportTestAsync()
        {
            var manager = new Mock<ISportManager>();
            Sport s = new Sport()
            {
                Id = 1,
                Name = "Sport"
            };

            manager.Setup(m => m.Update(1, s))
                .Callback((int id, Sport sport) => 
                {
                    id.Should().Be(1);
                    sport.Id.Should().Be(1);
                    sport.Name.Should().Be("Sport");
                })
                .ReturnsAsync(s);

            var controller = new SportsController(manager.Object);
            var actionResult = await controller.PutSport(1, s);


            // Checks the 204 response
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<NoContentResult>();
        }

        [TestMethod]
        public async System.Threading.Tasks.Task PutSportBadRequestTestAsync()
        {
            var manager = new Mock<ISportManager>();
            Sport s = new Sport()
            {
                Id = 1,
                Name = "Sport"
            };

            var controller = new SportsController(manager.Object);
            var actionResult = await controller.PutSport(2, s);

            // Checks the 400 response
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public async System.Threading.Tasks.Task PostSportTestAsync()
        {
            var manager = new Mock<ISportManager>();
            Sport s = new Sport()
            {
                Id = 1,
                Name = "Sport"
            };

            manager.Setup(m => m.Add(s))
                .Callback((Sport sport) =>
                {
                    sport.Id.Should().Be(1);
                    sport.Name.Should().Be("Sport");
                })
                .ReturnsAsync(s);

            var controller = new SportsController(manager.Object);
            var actionResult = await controller.PostSport(s);

            // Checks the 201 response
            actionResult.Result.Should().BeOfType<CreatedAtActionResult>();
            var result = actionResult.Result as CreatedAtActionResult;

            //Checks the content of the response
            var responseValue = result.Value as Sport;
            responseValue.Id.Should().Be(1);
            responseValue.Name.Should().Be("Sport");
        }

        [TestMethod]
        public async System.Threading.Tasks.Task DeleteSportTestAsync()
        {
            var manager = new Mock<ISportManager>();
            Sport s = new Sport()
            {
                Id = 1,
                Name = "Sport"
            };
            manager.Setup(m => m.DeleteAsync(1))
                .Callback((int id) =>
                {
                    id.Should().Be(1);
                })
                .ReturnsAsync(s);

            var controller = new SportsController(manager.Object);
            var actionResult = await controller.DeleteSport(1);

            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<ActionResult<Sport>>();

            // Checks the 200 response
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            var result = actionResult.Result as OkObjectResult;

            //Checks the content of the response
            var responseValue = result.Value as Sport;
            responseValue.Id.Should().Be(1);
            responseValue.Name.Should().Be("Sport");
        }

        [TestMethod]
        public async System.Threading.Tasks.Task DeleteSportNotFoundTestAsync()
        {
            var manager = new Mock<ISportManager>();
            Sport s = null;

            manager.Setup(m => m.DeleteAsync(11))
                .ReturnsAsync(s);

            var controller = new SportsController(manager.Object);
            var actionResult = await controller.DeleteSport(11);

            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<ActionResult<Sport>>();

            // Checks the 404 response
            actionResult.Result.Should().BeOfType<NotFoundResult>();
        }

    }
}
