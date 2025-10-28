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
using Xunit;

namespace QPlanning.Api.UnitTests.Controllers
{
    public class MedewerkerControllerAddUnitTests
    {
        [Fact]
        public async Task AddMedewerkerCommand_ReturnError_WhenFirstNameShorterThan2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("a", "Achter", "van", "a@b.c", 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnError_WhenLastNameShorterThan2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("Jan", "a", "van", "a@b.c", 125, 100);
            
            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnOK_WhenFirstNameIsExactly2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("aa", "Achter", "van", "a@b.c", 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnOK_WhenLastNameIsExactly2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("Jan", "aa", "van", "a@b.c", 125, 100);
            
            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnError_WhenFirstNameIsLongerThan100Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string voornaam = new string('a', 101);
            var command = new AddMedewerkerCommand(voornaam, "Achter", "van", "a@b.c", 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnError_WhenLastNameIsLongerThan100Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string achternaam = new string('a', 101);
            var command = new AddMedewerkerCommand("Jan", achternaam, "van", "a@b.c", 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnError_WhenNamePrefixIsLongerThan50Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string tussenVoegsel = new string('a', 51);
            var command = new AddMedewerkerCommand("Jan", "Achter", tussenVoegsel, "a@b.c", 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnOK_WhenFirstNameIsExactly100Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string voornaam = new string('a', 100);
            var command = new AddMedewerkerCommand(voornaam, "Achter", "van", "a@b.c", 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnOK_WhenLastNameIsExactly100Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string achternaam = new string('a', 100);
            var command = new AddMedewerkerCommand("Jan", achternaam, "van", "a@b.c", 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnOK_WhenNamePrefixIsExactly50Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string tussenVoegsel = new string('a', 50);
            var command = new AddMedewerkerCommand("Jan", "Achter", tussenVoegsel, "a@b.c", 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Theory]
        [InlineData("notanemailaddress")]
        [InlineData("missingatsign.com")]
        [InlineData("missingdomain@")]
        [InlineData("@missingusername.com")]
        public async Task AddMedewerkerCommand_ReturnError_WhenEmailIsInvalid(string invalidEmail)
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("Jan", "Achter", "van", invalidEmail, 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Theory]
        [InlineData("a@b.c")]
        [InlineData("some.person@example.com")]
        [InlineData("user+alias@sub.domain.nl")]
        public async Task AddMedewerkerCommand_ReturnsOK_WhenEmailIsValid(string validEmail)
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("Jan", "Achter", "van", validEmail, 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnError_WhenEmailIsLongerThan254Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string localPart = new string('a', 245);
            var email = $"{localPart}@something.com";
            var command = new AddMedewerkerCommand("Jan", "Achter", "van", email, 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnsOK_WhenEmailIsExactly254Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string localPart = new string('a', 242);
            var email = $"{localPart}@example.com";
            var command = new AddMedewerkerCommand("Jan", "Achter", "van", email, 125, 100);

            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnsError_WhenTarifIsZero()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("Jan", "Achter", "van", "a@b.c", 0, 100);
            
            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnsError_WhenInternalTarifIsZero()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("Jan", "Achter", "van", "a@b.c", 125, 0);
            
            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnsOK_WhenTarifIsOne()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("Jan", "Achter", "van", "a@b.c", 1, 100);
            
            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddMedewerkerCommand_ReturnsOK_WhenInternalTarifIsOne()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand("Jan", "Achter", "van", "a@b.c", 125, 1);
            
            var result = await controller.Add(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}
