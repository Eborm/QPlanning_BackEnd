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
using QPlanning.Business.UseCases.Medewerkers.Edit.Dto.Command;
using Xunit;

namespace QPlanning.Api.UnitTests.Controllers
{
    public class MedewerkerControllerUpdateUnitTests
    {
        //Test to ensure Voornaam cannot be shorter than 2 characters
        [Fact]
        public async Task EditMedewerkerCommand_ReturnError_WhenFirstNameShorterThan2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "a", "van", "Achter", "a@b.c", 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test to ensure Achternaam cannot be shorter than 2 characters
        [Fact]
        public async Task EditMedewerkerCommand_ReturnError_WhenLastNameShorterThan2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "Jan", "van", "a", "a@b.c", 125, 100, 1, true);
            
            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test for Voornaam exactly 2 characters long
        [Fact]
        public async Task EditMedewerkerCommand_ReturnOK_WhenFirstNameIsExactly2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "aa", "van", "Achter", "a@b.c", 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test for Achternaam exactly 2 characters long
        [Fact]
        public async Task EditMedewerkerCommand_ReturnOK_WhenLastNameIsExactly2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "Jan", "van", "aa", "a@b.c", 125, 100, 1, true);
            
            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test Voornaam longer than 100 characters
        [Fact]
        public async Task EditMedewerkerCommand_ReturnError_WhenFirstNameIsLongerThan100Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string voornaam = new string('a', 101);
            var command = new EditMedewerkerCommand(1, voornaam, "van", "Achter", "a@b.c", 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test Achternaam longer than 100 characters
        [Fact]
        public async Task EditMedewerkerCommand_ReturnError_WhenLastNameIsLongerThan100Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string achternaam = new string('a', 101);
            var command = new EditMedewerkerCommand(1, "Jan", "van", achternaam, "a@b.c", 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test Tussenvoegsel longer than 50 characters
        [Fact]
        public async Task EditMedewerkerCommand_ReturnError_WhenNamePrefixIsLongerThan50Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string tussenVoegsel = new string('a', 51);
            var command = new EditMedewerkerCommand(1, "Jan", tussenVoegsel, "Achter", "a@b.c", 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test Voornaam exactly 100 characters long
        [Fact]
        public async Task EditMedewerkerCommand_ReturnOK_WhenFirstNameIsExactly100Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string voornaam = new string('a', 100);
            var command = new EditMedewerkerCommand(1, voornaam, "van", "Achter", "a@b.c", 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test Achternaam exactly 100 characters long
        [Fact]
        public async Task EditMedewerkerCommand_ReturnOK_WhenLastNameIsExactly100Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string achternaam = new string('a', 100);
            var command = new EditMedewerkerCommand(1, "Jan", "van", achternaam, "a@b.c", 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test Tussenvoegsel exactly 50 characters long
        [Fact]
        public async Task EditMedewerkerCommand_ReturnOK_WhenNamePrefixIsExactly50Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string tussenVoegsel = new string('a', 50);
            var command = new EditMedewerkerCommand(1, "Jan", tussenVoegsel, "Achter", "a@b.c", 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test invalid email formats
        [Theory]
        [InlineData("notanemailaddress")]
        [InlineData("missingatsign.com")]
        [InlineData("missingdomain@")]
        [InlineData("@missingusername.com")]
        public async Task EditMedewerkerCommand_ReturnError_WhenEmailIsInvalid(string invalidEmail)
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "Jan", "van", "Achter", invalidEmail, 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test valid email formats
        [Theory]
        [InlineData("a@b.c")]
        [InlineData("some.person@example.com")]
        [InlineData("user+alias@sub.domain.nl")]
        public async Task EditMedewerkerCommand_ReturnsOK_WhenEmailIsValid(string validEmail)
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "Jan", "van", "Achter", validEmail, 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test email length validation
        [Fact]
        public async Task EditMedewerkerCommand_ReturnError_WhenEmailIsLongerThan254Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string localPart = new string('a', 245);
            var email = $"{localPart}@something.com";
            var command = new EditMedewerkerCommand(1, "Jan", "van", "Achter", email, 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test email exactly 254 characters
        [Fact]
        public async Task EditMedewerkerCommand_ReturnsOK_WhenEmailIsExactly254Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string localPart = new string('a', 242);
            var email = $"{localPart}@example.com";
            var command = new EditMedewerkerCommand(1, "Jan", "van", "Achter", email, 125, 100, 1, true);

            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test Tarief and InternTarief cannot be zero
        [Fact]
        public async Task EditMedewerkerCommand_ReturnsError_WhenTarifIsZero()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "Jan", "van", "Achter", "a@b.c", 0, 100, 1, true);
            
            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task EditMedewerkerCommand_ReturnsError_WhenInternalTarifIsZero()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "Jan", "van", "Achter", "a@b.c", 125, 0, 1, true);
            
            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        //Test Tarief and InternTarief boundary 1
        [Fact]
        public async Task EditMedewerkerCommand_ReturnsOK_WhenTarifIsOne()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "Jan", "van", "Achter", "a@b.c", 1, 100, 1, true);
            
            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact]
        public async Task EditMedewerkerCommand_ReturnsOK_WhenInternalTarifIsOne()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<EditMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new EditMedewerkerCommand(1, "Jan", "van", "Achter", "a@b.c", 125, 1, 1, true);
            
            var result = await controller.Update(command);
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}
