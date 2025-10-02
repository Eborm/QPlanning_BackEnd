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
  public class KlantControllerUnitTests
  {
    //Tests to check the limits of the budget for klanten
    [Fact]
    public async void AddKlantenCommand_ReturnsOkWhenBudgetIsMoreThan0()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      mockMediator
        .Setup(med => med.Send(It.IsAny<AddKlantenCommand>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new KlantResponse(0, true, "OK"));

      var controller = new KlantController(mockMediator.Object);

      var command = new AddKlantenCommand { Budget = 1};

      // Act
      var result = await controller.Add(command);

      // Assert
      var objectResult = Assert.IsAssignableForm<ObjectResult>(result);
      Assert.Eqaul((int)HttpStatusCode.OK, objectResult.StatusCode);
    }
  }
}
