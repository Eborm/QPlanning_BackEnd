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
using QPlanning.Business.UseCases.Authentication.Account.Update.Dto.Command;

namespace QPlanning.Api.UnitTests.Controllers
{
    public class AccountControllerUpdateUnitTests
    {
        [Fact]
        public async void UpdateUserPost_ReturnsOK_WhenMediatorSendIsCalledCorrectly()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);

            // Act
            var result = await controller.Update(new UpdateUserCommand
            {
                Id = 1,
                Voornaam = "Voor",
                Achternaam = "Achter",
                Email = "email@email.com",
                UserName = "TestUser"
            });

            // Assert
            var statusCode = ((OkObjectResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
        }

        // Controleer dat het updaten van een account een error teruggeeft als Voornaam korter is dan 2 karakters
        [Fact]
        public async Task UpdateUserCommand_ReturnsError_WhenFirstNameShorterThanTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new AccountController(mockMediator.Object);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "a", Achternaam = "Achter", Email = "email@email.com", UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account geen error teruggeeft als Voornaam exact 2 karakters is
        [Fact]
        public async Task UpdateUserCommand_ReturnsOK_WhenFirstNameExactlyTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "aa", Achternaam = "Achter", Email = "email@email.com", UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account een error teruggeeft als Voornaam langer is dan 100 karakters
        [Fact]
        public async Task UpdateUserCommand_ReturnsError_WhenFirstNameLongerThanHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new AccountController(mockMediator.Object);
            string voornaam = new string('a', 101);
            var command = new UpdateUserCommand { Id = 1, Voornaam = voornaam, Achternaam = "Achter", Email = "email@email.com", UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account geen error teruggeeft als Voornaam exact 100 karakters is
        [Fact]
        public async Task UpdateUserCommand_ReturnsOK_WhenFirstNameExactlyHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string voornaam = new string('a', 100);
            var command = new UpdateUserCommand { Id = 1, Voornaam = voornaam, Achternaam = "Achter", Email = "email@email.com", UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account een error teruggeeft als Achternaam korter is dan 2 karakters
        [Fact]
        public async Task UpdateUserCommand_ReturnsError_WhenLastNameShorterThanTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new AccountController(mockMediator.Object);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "a", Email = "email@email.com", UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account geen error teruggeeft als Achternaam exact 2 karakters is
        [Fact]
        public async Task UpdateUserCommand_ReturnsOK_WhenLastNameExactlyTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "aa", Email = "email@email.com", UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account een error teruggeeft als Achternaam langer is dan 100 karakters
        [Fact]
        public async Task UpdateUserCommand_ReturnsError_WhenLastNameLongerThanHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new AccountController(mockMediator.Object);
            string achternaam = new string('a', 101);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = achternaam, Email = "email@email.com", UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account geen error teruggeeft als Achternaam exact 100 karakters is
        [Fact]
        public async Task UpdateUserCommand_ReturnsOK_WhenLastNameExactlyHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string achternaam = new string('a', 100);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = achternaam, Email = "email@email.com", UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account een error teruggeeft als UserName korter is dan 2 karakters
        [Fact]
        public async Task UpdateUserCommand_ReturnsError_WhenUserNameShorterThanTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new AccountController(mockMediator.Object);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "Achter", Email = "email@email.com", UserName = "a" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account geen error teruggeeft als UserName exact 2 karakters is
        [Fact]
        public async Task UpdateUserCommand_ReturnsOK_WhenUserNameExactlyTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "Achter", Email = "email@email.com", UserName = "aa" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account een error teruggeeft als UserName langer is dan 100 karakters
        [Fact]
        public async Task UpdateUserCommand_ReturnsError_WhenUserNameLongerThanHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new AccountController(mockMediator.Object);
            string userName = new string('a', 101);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "Achter", Email = "email@email.com", UserName = userName };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account geen error teruggeeft als UserName exact 100 karakters is
        [Fact]
        public async Task UpdateUserCommand_ReturnsOK_WhenUserNameExactlyHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string userName = new string('a', 100);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "Achter", Email = "email@email.com", UserName = userName };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account een error teruggeeft als Email niet voldoet aan 'a@b.c' syntax
        [Theory]
        [InlineData("notanemailaddress")]
        [InlineData("missingatsign.com")]
        [InlineData("missingdomain@")]
        [InlineData("@missingusername.com")]
        public async Task UpdateUserCommand_ReturnsError_WhenEmailIsInvalid(string invalidEmail)
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new AccountController(mockMediator.Object);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "Achter", Email = invalidEmail, UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account geen error geeft als Email geldig is
        [Theory]
        [InlineData("a@b.c")]
        [InlineData("some.person@example.com")]
        [InlineData("user+alias@sub.domain.nl")]
        public async Task UpdateUserCommand_ReturnsOk_WhenEmailIsValid(string validEmail)
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "Achter", Email = validEmail, UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account een error teruggeeft als een email langer is dan 254 karakters
        [Fact]
        public async Task UpdateUserCommand_ReturnError_WhenEmailIsLongerThan254Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new AccountController(mockMediator.Object);
            string localPart = new string('a', 245);
            var email = $"{localPart}@something.com";
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "Achter", Email = email, UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het updaten van een account geen error teruggeeft als een email exact 254 karakters is
        [Fact]
        public async Task UpdateUserCommand_ReturnsOk_WhenEmailIsExactly254Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string localPart = new string('a', 242); // 254 - 12 voor het domein gedeelte
            var email = $"{localPart}@example.com";
            var command = new UpdateUserCommand { Id = 1, Voornaam = "Voor", Achternaam = "Achter", Email = email, UserName = "Gebruiker" };

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}