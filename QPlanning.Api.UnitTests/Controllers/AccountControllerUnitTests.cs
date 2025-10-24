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
        public async void CreateUserPost_ReturnsOK_WhenMediatorSendIsCalledCorrectly()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);

            // Act
            var result = await controller.Add(new CreateUserCommand("Voor","Achter","email@email.com","email@email.com","Test@1234"));

            // Assert
            var statusCode = ((OkObjectResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
        }
        
        // Controleer dat het maken van een account een error teruggeeft als Voornaam korter is dan 2 karakters
        [Fact]
        public async Task CreateUserCommand_ReturnsError_WhenFirstNameShorterThanTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new CreateUserCommand("a", "Achter", "email@email.com", "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account een error teruggeeft als Achternaam korter is dan 2 karakters
        [Fact]
        public async Task CreateUserCommand_ReturnsError_WhenLastNameShorterThanTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new CreateUserCommand("Voor", "a", "email@email.com", "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account een error teruggeeft als UserName korter is dan 2 karakters
        [Fact]
        public async Task CreateUserCommand_ReturnsError_WhenUserNameShorterThanTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new CreateUserCommand("Voor", "Achter", "email@email.com", "a", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account geen error teruggeeft als Voornaam exact 2 karakters is
        [Fact]
        public async Task CreateUserCommand_ReturnsOK_WhenFirstNameExactlyTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new CreateUserCommand("aa", "Achter", "email@email.com", "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account geen error teruggeeft als Achternaam exact 2 karakters is
        [Fact]
        public async Task CreateUserCommand_ReturnsOK_WhenLastNameExactlyTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new CreateUserCommand("Voor", "aa", "email@email.com", "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account geen error teruggeeft als UserName exact 2 karakters is
        [Fact]
        public async Task CreateUserCommand_ReturnsOK_WhenUserNameExactlyTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            var command = new CreateUserCommand("Voor", "Achter", "email@email.com", "aa", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account een error teruggeeft als Voornaam langer is dan 100 karakters
        [Fact]
        public async Task CreateUserCommand_ReturnsError_WhenFirstNameLongerThanHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string voornaam = new string('a', 101);
            var command = new CreateUserCommand(voornaam, "Achter", "email@email.com", "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account een error teruggeeft als Achternaam langer is dan 100 karakters
        [Fact]
        public async Task CreateUserCommand_ReturnsError_WhenLastNameLongerThanHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string achternaam = new string('a', 101);
            var command = new CreateUserCommand("Voor", achternaam, "email@email.com", "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account een error teruggeeft als UserName langer is dan 100 karakters
        [Fact]
        public async Task CreateUserCommand_ReturnsError_WhenUserNameLongerThanHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string userName = new string('a', 101);
            var command = new CreateUserCommand("Voor", "Achter", "email@email.com", userName, "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account geen error teruggeeft als Voornaam exact 100 karakters is
        [Fact]
        public async Task CreateUserCommand_ReturnsOK_WhenFirstNameExactlyHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string voornaam = new string('a', 100);
            var command = new CreateUserCommand(voornaam, "Achter", "email@email.com", "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account geen error teruggeeft als Achternaam exact 100 karakters is
        [Fact]
        public async Task CreateUserCommand_ReturnsOK_WhenLastNameExactlyHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string achternaam = new string('a', 100);
            var command = new CreateUserCommand("Voor", achternaam, "email@email.com", "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account geen error teruggeeft als UserName exact 100 karakters is
        [Fact]
        public async Task CreateUserCommand_ReturnsOK_WhenUserNameExactlyHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));

            var controller = new AccountController(mockMediator.Object);
            string userName = new string('a', 100);
            var command = new CreateUserCommand("Voor", "Achter", "email@email.com", userName, "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account een error teruggeeft als Email niet voldoet aan 'a@b.c' syntax
        [Theory]
        [InlineData("notanemailaddress")]
        [InlineData("missingatsign.com")]
        [InlineData("missingdomain@")]
        [InlineData("@missingusername.com")]
        [InlineData("name@domain")]
        [InlineData("name@.com")]
        [InlineData("name@domain..com")]
        public async Task CreateUserCommand_ReturnsError_WhenEmailIsInvalid(string invalidEmail)
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));
            
            var controller = new AccountController(mockMediator.Object);
            var command = new CreateUserCommand("Voor", "Achter", invalidEmail, "email@email.com", "Test@1234");
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account geen error geeft als Email geldig is
        [Theory]
        [InlineData("a@b.c")]
        [InlineData("some.person@example.com")]
        [InlineData("user+alias@sub.domain.nl")]
        public async Task CreateUserCommand_ReturnsOk_WhenEmailIsValid(string validEmail)
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BaseResponse("", true)));
            
            var controller = new AccountController(mockMediator.Object);
            var command = new CreateUserCommand("Voor", "Achter", validEmail, validEmail, "Test@1234");
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account een error teruggeeft als een email langer is dan 254 karakters
        [Fact]
        public async Task CreateUserCommand_ReturnError_WhenEmailIsLongerThan254Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new AccountController(mockMediator.Object);
            
            string localPart = new string('a', 245);
            var email = $"{localPart}@something.com";

            var command = new CreateUserCommand("Voor", "Achter", email, "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account geen error teruggeeft als een email exact 254 karakters is
        [Fact]
        public async Task CreateUserCommand_ReturnsOk_WhenEmailIsExactly254Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new AccountController(mockMediator.Object);
            
            string localPart = new string('a', 242); // 254 - 12 voor het domein gedeelte
            var email = $"{localPart}@example.com";

            var command = new CreateUserCommand("Voor", "Achter", email, "email@email.com", "Test@1234");

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account een error teruggeeft bij ongeldige wachtwoorden
        [Theory]
        [InlineData("test@1234")]
        [InlineData("TEST@1234")]
        [InlineData("Test@abcd")]
        public async Task CreateUserCommand_ReturnsError_WhenPasswordIsInvalid(string invalidPassword)
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new AccountController(mockMediator.Object);

            var command = new CreateUserCommand("Voor", "Achter", "email@email.com", "email@email.com", invalidPassword);
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een account geen error teruggeeft bij geldige wachtwoorden
        [Fact]
        public async Task CreateUserCommand_ReturnsOk_WhenPasswordIsValid()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new AccountController(mockMediator.Object);

            var command = new CreateUserCommand("Voor", "Achter", "email@email.com", "email@email.com", "Test@1234");
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}