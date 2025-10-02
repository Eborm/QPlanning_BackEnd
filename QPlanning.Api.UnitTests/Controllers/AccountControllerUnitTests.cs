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

namespace QPlanning.Api.UnitTests.Controllers
{
    public class AccountControllerUnitTests
    {
        [Fact]
        public async void CreateUser_Post_Returns_Ok_When_Mediator_Send_Is_Called_Correctly()
        {
            // arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);

            // act
            var result = await controller.Add(new CreateUserCommand("","","","",""));

            // assert
            var statusCode = ((OkObjectResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
        }
    }
}