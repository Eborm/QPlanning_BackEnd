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

namespace QPlanning.Api.Unittests.Controllers
{
    public class BoekingControllerUnitTests
    {
        //Tests to check the limits of how long a booking lasts

        [Fact]
        public async void AddBoekingCommand_ReturnsErrorWhenBoekingLastsLongerThan24Hours()
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
        public async void AddBoekingCommand_ReturnErrorWhenBoekingLastsLessThan1Hours()
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
        public async void AddBoekingCommand_ReturnsOKWhenBoekingLasts24Hours()
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
        public async void AddBoekingCommand_ReturnsOKWhenBoekingLasts1Hours()
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
        public async void AddBoekingCommand_ReturnsOKWhenBoekingDateIsToday()
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
        public async void AddBoekingCommand_ReturnsOkWhenBoekingDateIsInFuture()
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
        public async void AddBoekingCommand_ReturnsErrorWhenBoekingDateIsInPast()
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
        public async void AddBoekingCommand_ReturnsOkWhenBookingYearIsThisYear()
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

            //Assert
            var ObjectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, ObjectResult.StatusCode);
        }

        [Fact]
        public async void AddboekingCommand_ReturnsOkWhenBookingYearIsInFuture()
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
            var ObjectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, ObjectResult.StatusCode);
        }

        [Fact]
        public async void AddBoekingCommand_ReturnsErrorWhenBookingYearIsInPast()
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
            var ObjectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, ObjectResult.StatusCode);
        }

        
        [Fact]
        public async void AddBoekingCommand_ReturnsOkWhenBoekingWeekIsMoreThan0()
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
          var ObjectResult = Assert.IsAssignableFrom<ObjectResult>(result);
          Assert.Equal((int)HttpStatusCode.OK, ObjectResult.StatusCode);
        }

        [Fact]
        public async void AddBoekingCommand_ReturnsOkWhenBoekingWeekIsLeseThan53()
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
          var ObjectResult = Assert.IsAssignableFrom<ObjectResult>(result);
          Assert.Equal((int)HttpStatusCode.OK, ObjectResult.StatusCode);
        }

        [Fact]
        public async void AddBoekingCommand_ReturnsErrorWhenBoekingWeekIsLessThan1()
        {
          // Arrange
          var mockMediator = new Mock<IMediator>();
          mockMediator
            .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BoekingResponse(0, true, "OK"));

          var controller = new BoekingController(mockMediator.ObjectResult);

          var command = new AddBoekingCommand { Weeknummer = 0};

          // Act
          var result = await controller.Add(command);

          // Assert
          var ObjectResult = Assert.IsAssignableFrom<ObjectResult>(result);
          Assert.Equal((int)HttpStatusCode.OK, ObjectResult.StatusCode);
        }

        [Fact]
        public async void AddBoekingCommand_ReturnsErrorWhenBoekingWeekIsMoreThan52()
        {
          // Arrange
          var mockMediator = new Mock<IMediator>();
          mockMediator
            .Setup(med => med.Send(It.IsAny<AddBoekingCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BoekingResponse(0, true, "OK"));

          var controller = new BoekingController(mockMediator.ObjectResult);

          var command = new AddBoekingCommand { Weeknummer = 53};

          // Act
          var result = await controller.Add(command);

          // Assert
          var ObjectResult = Assert.IsAssignableFrom<ObjectResult>(result);
          Assert.Equal((int)HttpStatusCode.OK, ObjectResult.StatusCode);
        }
    }
}
