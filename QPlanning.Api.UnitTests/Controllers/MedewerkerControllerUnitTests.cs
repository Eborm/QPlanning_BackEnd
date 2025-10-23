using System.Net;
using System.Runtime.InteropServices.JavaScript;
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

namespace QPlanning.Api.Unittests.Controllers
{
    public class MedewerkerControllerUnitTests
    {
        // Deze unit-tests testen de correcte validatie van de velden in Medewerker, dit zijn:
        // Voornaam, Achternaam, TussenVoegsel, Email, Tarief, InternTarief
        
        // Controleer dat het maken van een medewerker een error teruggeeft als Voornaam korter is dan 2 karakters
        [Fact]
        public async Task AddMedewerkerCommand_ReturnErrorWhenFirstNameShorterThan2Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { Voornaam = "a" };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker een error teruggeeft als Achternaam korter is dan 2 karakters
        [Fact]
        public async Task AddMedewerkerCommand_ReturnErrorWhenLastNameShorterThan2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { Achternaam = "a" };
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker geen error teruggeeft als Voornaam exact 2 karakters is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnOKWhenFirstNameIsExactly2Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { Voornaam = "aa" };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker geen error teruggeeft als Achternaam exact 2 karakters lang is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnOKWhenLastNameIsExactly2Characters()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { Achternaam = "aa" };
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker een error teruggeeft als Voornaam langer is dan 100 karakters
        [Fact]
        public async Task AddMedewerkerCommand_ReturnErrorWhenFirstNameIsLongerThan100Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            
            string voornaam = new string('a', 101);
            var command = new AddMedewerkerCommand { Voornaam = voornaam };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker een error teruggeeft als Achternaam langer is dan 100 karakters
        [Fact]
        public async Task AddMedewerkerCommand_ReturnErrorWhenLastNameIsLongerThan100Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string achternaam = new string('a', 101);
            var command = new AddMedewerkerCommand { Achternaam = achternaam };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
                
        // Controleer dat het maken van een medewerker een error teruggeeft als Tussenvoegsel langer is dan 50 karakters
        [Fact]
        public async Task AddMedewerkerCommand_ReturnErrorWhenNamePrefixIsLongerThan50Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);

            string tussenVoegsel = new string('a', 51);
            var command = new AddMedewerkerCommand { TussenVoegsel = tussenVoegsel };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker geen error teruggeeft als Voornaam exact 100 karakters is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnOKWhenFirstNameIsExactly100Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            
            string voornaam = new string('a', 100);
            var command = new AddMedewerkerCommand { Voornaam = voornaam };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker geen error teruggeeft als Achternaam exact 100 karakters lang is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnOKWhenLastNameIsExactly100Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            string achternaam = new string('a', 100);
            var command = new AddMedewerkerCommand { Achternaam = achternaam };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker geen error teruggeeft als Tussenvoegsel exact 50 karakters is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnOKWhenNamePrefixIsExactly50Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);

            string tussenVoegsel = new string('a', 50);
            var command = new AddMedewerkerCommand { TussenVoegsel = tussenVoegsel };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker een error teruggeeft als Email niet voldoet aan 'a@b.c' syntax
        [Theory]
        [InlineData("notanemailaddress")]
        [InlineData("missingatsign.com")]
        [InlineData("missingdomain@")]
        [InlineData("@missingusername.com")]
        [InlineData("name@domain")]
        [InlineData("name@.com")]
        [InlineData("name@domain..com")]
        public async Task AddMedewerkerCommand_ReturnErrorWhenEmailIsInvalid(string invalidEmail)
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { Email = invalidEmail };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker geen error geeft als Email geldig is
        [Theory]
        [InlineData("a@b.c")]
        [InlineData("john.doe@example.com")]
        [InlineData("user+alias@sub.domain.co.uk")]
        public async Task AddMedewerkerCommand_ReturnsOkWhenEmailIsValid(string validEmail)
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { Email = validEmail };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker een error teruggeeft als een email langer is dan 254 karakters
        [Fact]
        public async Task AddMedewerkerCommand_ReturnErrorWhenEmailIsLongerThan254Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            
            string localPart = new string('a', 245);
            var email = $"{localPart}@something.com";

            var command = new AddMedewerkerCommand { Email = email };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker geen error teruggeeft als een email exact 254 karakters is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnsOkWhenEmailIsExactly254Characters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));

            var controller = new MedewerkerController(mockMediator.Object);
            
            string localPart = new string('a', 242); // 254 - 12 for the domain part
            var email = $"{localPart}@example.com";

            var command = new AddMedewerkerCommand { Email = email };

            // Act
            var result = await controller.Add(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker een error teruggeeft als Tarief 0 is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnsErrorWhenTarifIsZero()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { Tarief = 0 };
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker een error teruggeeft als InternTarief 0 is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnsErrorWhenInternalTarifIsZero()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { InternTarief = 0 };
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker geen error teruggeeft als Tarief 1 is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnsOKWhenTarifIsOne()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { Tarief = 1 };
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
        
        // Controleer dat het maken van een medewerker geen error teruggeeft als InternTarief 1 is
        [Fact]
        public async Task AddMedewerkerCommand_ReturnsOKWhenInternalTarifIsOne()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<AddMedewerkerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("1", true, "OK"));
            
            var controller = new MedewerkerController(mockMediator.Object);
            var command = new AddMedewerkerCommand { InternTarief = 1 };
            
            // Act
            var result = await controller.Add(command);
            
            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}

