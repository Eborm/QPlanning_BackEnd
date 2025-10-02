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

namespace QPlanning.Api.Unittests.Controllers
{
  public class KlantControllerUnitTests
  {
    //Tests to check the limits of the budget for klanten
    [Fact]
    public async void AddKlantenCommand_ReturnsOkWhenBudgetIsMoreThan0()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      mockMediator
        .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new BaseResponse("1", true, "OK"));

      var controller = new KlantController(mockMediator.Object);

      var command = new AddKlantCommand { Budget = 1};

      // Act
      var result = await controller.Add(command);

      // Assert
      var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
      Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
    }

    [Fact]
    public async void AddKlantenCommand_ReturnsErrorWhenBudgetIsLessThan1()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      mockMediator
        .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new BaseResponse("1", true, "OK"));

      var controller = new KlantController(mockMediator.Object);

      var command = new AddKlantCommand { Budget = 0};

      // Act
      var result = await controller.Add(command);

      // Assert
      var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
      Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
    }

    //Tests to check the start and end date for a klant
    [Fact]
    public async void AddKlantCommand_ReturnsOkWhenStartdatumIsToday()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      mockMediator
        .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new BaseResponse("1", true, "OK"));

      var controller = new KlantController(mockMediator.Object);

      var command = new AddKlantCommand { Startdatum = System.DateTime.Today };

      // Act
      var result = await controller.Add(command);

      // Assert
      var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
      Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
    }

    [Fact]
    public async void AddKlantCommand_ReturnsOkWhenEndDateDoesNotEqualStartDateAndIsNotBeforeStartDate()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      mockMediator
        .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new BaseResponse("1", true, "OK"));

      var controller = new KlantController(mockMediator.Object);

            var command = new AddKlantCommand { Startdatum = System.DateTime.Today, Einddatum = System.DateTime.Today.AddDays(1) };

      // Act
      var result = await controller.Add(command);

      // Assert
      var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
      Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
    }

    [Fact]
    public async void AddKlantCommand_ReturnsOkWhenStartDateInFuture()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      mockMediator
        .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new BaseResponse("1", true, "OK"));

      var controller = new KlantController(mockMediator.Object);

      var command = new AddKlantCommand { Startdatum = System.DateTime.Today.AddDays(1)};

      // Act
      var result = await controller.Add(command);

      // Assert
      var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
      Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
    }

    [Fact]
    public async void AddKlantCommand_ReturnsErrorWhenStartDateIsInPast()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      mockMediator
        .Setup(med => med.Send(It.IsAny<AddKlantCommand>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new BaseResponse("1", true, "OK"));

      var controller = new KlantController(mockMediator.Object);

      var command = new AddKlantCommand { Startdatum = System.DateTime.Today.AddDays(-1)};

      // Act
      var result = await controller.Add(command);

      var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
      Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
    }
  }
}
