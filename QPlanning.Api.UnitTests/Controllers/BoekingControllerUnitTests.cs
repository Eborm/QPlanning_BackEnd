using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using QPlanning.Api.Controllers;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.UseCases.Boeking.Add.Dto;
using QPlanning.Business.UseCases.Boeking.Get.Models;
using QPlanning.Business.UseCases.Boeking.Dto;
using Microsoft.VisualBasic.FileIO;

namespace QPlanning.Api.UnitTests.Controllers
{
    public class BoekingControllerUnitTests
    {
        //Tests to check the limits of how long a booking lasts

        [Fact]
        public async Task AddBoekingCommand_ReturnsError_WhenBoekingLastsLongerThan24Hours()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController(mockMediator.Object);

            var command = new AddBoekingCommand { Uren = 25 };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddBoekingCommand_ReturnError_WhenBoekingLastsLessThan1Hours()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController(mockMediator.Object);

            var command = new AddBoekingCommand { Uren = 0 };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddBoekingCommand_ReturnsOK_WhenBoekingLasts24Hours()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController (mockMediator.Object);

            var command = new AddBoekingCommand { Uren = 24 };

            // Act
            var result = await controller.Add(command);

            //Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddBoekingCommand_ReturnsOK_WhenBoekingLasts1Hours()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController(mockMediator.Object);

            var command = new AddBoekingCommand { Uren = 1 };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }


        //Test to check when a booking can be added depending on date
        [Fact]
        public async Task AddBoekingCommand_ReturnsOK_WhenBoekingDateIsToday()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController(mockMediator.Object);

            var command = new AddBoekingCommand { PlannedDate = System.DateTime.Today };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddBoekingCommand_ReturnsOk_WhenBoekingDateIsInFuture()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController(mockMediator.Object);

            var command = new AddBoekingCommand { PlannedDate = System.DateTime.Today.AddDays(1) };
        
            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);



        }

        [Fact]
        public async Task AddBoekingCommand_ReturnsError_WhenBoekingDateIsInPast()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController(mockMediator.Object);

            var command = new AddBoekingCommand { PlannedDate = System.DateTime.Today.AddDays(-1) };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Tests to check if a booking can be added depending on year
        [Fact]
        public async Task AddBoekingCommand_ReturnsOk_WhenBookingYearIsThisYear()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController(mockMediator.Object);

            var command = new AddBoekingCommand { Boekjaar = System.DateTime.Today.Year };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddboekingCommand_ReturnsOk_WhenBookingYearIsInFuture()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController(mockMediator.Object);

            var command = new AddBoekingCommand { Boekjaar = System.DateTime.Today.Year + 1 };
        
            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddBoekingCommand_ReturnsError_WhenBookingYearIsInPast()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BoekingResponse(0, true, "OK"));

            var controller = new BoekingController(mockMediator.Object);

            var command = new AddBoekingCommand { Boekjaar = System.DateTime.Today.Year - 1 };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        
        [Fact]
        public async Task AddBoekingCommand_ReturnsOk_WhenBoekingWeekIsMoreThan0()
        {
          // Arrange
          var mockMediator = new Mock<IMediator>();
          mockMediator
            .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BoekingResponse(0, true, "OK"));

          var controller = new BoekingController(mockMediator.Object);

          var command = new AddBoekingCommand { Weeknummer = 1};

          // Act
          var result = await controller.Add(command);

          // Assert
          var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
          Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddBoekingCommand_ReturnsOk_WhenBoekingWeekIsLessThan53()
        {
          // Arrange
          var mockMediator = new Mock<IMediator>();
          mockMediator
            .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BoekingResponse(0, true, "OK"));

          var controller = new BoekingController(mockMediator.Object);

          var command =  new AddBoekingCommand { Weeknummer = 52};

          // Act
          var result = await controller.Add(command);

          // Assert
          var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
          Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddBoekingCommand_ReturnsError_WhenBoekingWeekIsLessThan1()
        {
          // Arrange
          var mockMediator = new Mock<IMediator>();
          mockMediator
            .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BoekingResponse(0, true, "OK"));

          var controller = new BoekingController(mockMediator.Object);

          var command = new AddBoekingCommand { Weeknummer = 0};

          // Act
          var result = await controller.Add(command);

          // Assert
          var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
          Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddBoekingCommand_ReturnsError_WhenBoekingWeekIsMoreThan52()
        {
          // Arrange
          var mockMediator = new Mock<IMediator>();
          mockMediator
            .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BoekingResponse(0, true, "OK"));

          var controller = new BoekingController(mockMediator.Object);

          var command = new AddBoekingCommand { Weeknummer = 53};

          // Act
          var result = await controller.Add(command);

          // Assert
          var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
          Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}
