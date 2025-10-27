using System;
using System.Collections.Generic;
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
using QPlanning.Business.UseCases.Klanten.Add.Dto.Commands;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Responses;

namespace QPlanning.Api.UnitTests.Controllers
{
    public class KlantControllerUnitTests
    {
        private AddKlantCommand CreateCommand(
            int id = 1,
            string name = "Some company",
            DateTime startDatum = default,
            DateTime eindDatum = default,
            int verantwoordelijkTeamId = 1,
            int medewerkerId = 1,
            List<int> planbaarDoorTeamsIds = default,
            int boekjaar = 2025,
            int budget = 1000)
        {
            if (startDatum == default) startDatum = DateTime.Now;
            if (eindDatum == default) eindDatum = DateTime.Now.AddDays(1);
            if (planbaarDoorTeamsIds == default)
            {
                planbaarDoorTeamsIds = new List<int>();
                planbaarDoorTeamsIds.Add(1);
            }
            
            return new AddKlantCommand(
                id,
                name,
                startDatum,
                eindDatum,
                verantwoordelijkTeamId,
                medewerkerId,
                planbaarDoorTeamsIds,
                boekjaar,
                budget
            );
        }
        
        // Tests to validate name rules for klant
        [Fact]
        public async Task AddKlantCommand_ReturnsError_WhenNameIsShorterThanTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateCommand(name: "a");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        [Fact]
        public async Task AddKlantCommand_ReturnsError_WhenNameIsLongerThanHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new KlantController(mockMediator.Object);
            
            string longName = new string('a', 101);
            var command = CreateCommand(name: longName);

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        [Fact]
        public async Task AddKlantCommand_ReturnsOK_WhenNameIsExactlyTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateCommand(name: "aa");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        [Fact]
        public async Task AddKlantCommand_ReturnsOK_WhenNameIsExactlyHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new KlantController(mockMediator.Object);

            string longName = new string('a', 100);
            var command = CreateCommand(name: longName);

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Tests to check the limits of the budget for klanten
        [Fact]
        public async Task AddKlantCommand_ReturnsOK_WhenBudgetIsMoreThan0()
        {
              // Arrange
              var mockMediator = new Mock<IMediator>();
              mockMediator
                .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

              var controller = new KlantController(mockMediator.Object);

              var command = CreateCommand(budget: 1);

              // Act
              var result = await controller.Add(command);

              // Assert
              var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
              Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddKlantCommand_ReturnsError_WhenBudgetIsLessThan1()
        {
              // Arrange
              var mockMediator = new Mock<IMediator>();
              mockMediator
                .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

              var controller = new KlantController(mockMediator.Object);

              var command = CreateCommand(budget: 0);

              // Act
              var result = await controller.Add(command);

              // Assert
              var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
              Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Tests to check the start and end date for a klant
        [Fact]
        public async Task AddKlantCommand_ReturnsOK_WhenStartdatumIsToday()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
              .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateCommand(startDatum: DateTime.Today);

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddKlantCommand_ReturnsOK_WhenEndDateDoesNotEqualStartDateAndIsNotBeforeStartDate()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
              .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateCommand(startDatum: DateTime.Today, eindDatum: DateTime.Today.AddDays(1));

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddKlantCommand_ReturnsOK_WhenStartDateInFuture()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
              .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateCommand(startDatum: DateTime.Today.AddDays(1));

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddKlantCommand_ReturnsError_WhenStartDateIsInPast()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
              .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateCommand(startDatum: DateTime.Today.AddDays(-1));

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddKlantCommand_ReturnsError_WhenEnddateBeforeStartDate()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
              .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateCommand(startDatum: DateTime.Today, eindDatum: DateTime.Today.AddDays(-1));

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}
