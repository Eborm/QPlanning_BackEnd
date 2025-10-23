using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QPlanning.Api.Controllers;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.UseCases.Medewerkers.Add.Dto.Command;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;
using Xunit;

namespace QPlanning.Api.Unittests
{
    public class MedewerkerControllerUnitTests
    {
        [Fact]
        public async Task AddMedewerkerCommand_ReturnErrorWhenNaamShorterThan2Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);

            var command = new AddMedewerkerCommand { Voornaam = "a"};

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }

}

