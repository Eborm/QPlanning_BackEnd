using System;
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
    public class BoekingControllerAddUnitTests
    {
        private AddBoekingCommand CreateAddCommand(
            int id = 1,
            int jaar = 2025,
            int boekjaar = 2025,
            int weeknummer = 1,
            int uren = 8,
            DateTime plannedDate = default,
            int medewerkerId = 1,
            int klantId = 1,
            int opdrachtId = 1,
            int indirecteUrenId = 1)
        {
            if (plannedDate == default)
                plannedDate = DateTime.Today;

            return new AddBoekingCommand(
                id,
                jaar,
                boekjaar,
                weeknummer,
                uren,
                plannedDate,
                medewerkerId,
                klantId,
                opdrachtId,
                indirecteUrenId
            );
        }
        
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

            var command = CreateAddCommand(uren: 25);
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

            var command = CreateAddCommand(uren: 0);

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

            var command = CreateAddCommand(uren: 24);

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

            var command = CreateAddCommand(uren: 1);

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

            var command = CreateAddCommand(plannedDate: DateTime.Today);

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

            var command = CreateAddCommand(plannedDate: System.DateTime.Today.AddDays(1));
        
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

            var command = CreateAddCommand(plannedDate: System.DateTime.Today.AddDays(-1));

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

            var command = CreateAddCommand(boekjaar: System.DateTime.Today.Year);

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

            var command = CreateAddCommand (boekjaar: System.DateTime.Today.Year + 1);
        
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

            var command = CreateAddCommand (boekjaar: System.DateTime.Today.Year - 1);

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

          var command = CreateAddCommand(weeknummer: 1);

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

          var command = CreateAddCommand(weeknummer: 52);

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

          var command = CreateAddCommand(weeknummer: 0);

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

          var command = CreateAddCommand(weeknummer: 53);

          // Act
          var result = await controller.Add(command);

          // Assert
          var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
          Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}
