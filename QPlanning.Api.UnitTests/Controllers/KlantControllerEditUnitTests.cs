using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using QPlanning.Api.Controllers;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.UseCases.Klanten.Edit.Dto.Commands;

namespace QPlanning.Api.UnitTests.Controllers
{
    public class KlantControllerEditUnitTests
    {
        private EditKlantCommand CreateEditCommand(
            int id = 1,
            string naam = "Some company",
            DateTime startDatum = default,
            DateTime eindDatum = default,
            int verantwoordelijkTeamId = 1,
            int medewerkerId = 1,
            DomainModelTeam verantwoordelijkTeam = default,
            IEnumerable<int> planbaarDoorTeamsIds = default,
            IEnumerable<DomainModelBoekjaar> boekjaren = default)
        {
            if (startDatum == default) startDatum = DateTime.Now;
            if (eindDatum == default) eindDatum = DateTime.Now.AddDays(1);
            if (verantwoordelijkTeam == default)
            {
                verantwoordelijkTeam = new DomainModelTeam
                {
                    Id = 1,
                    Naam = "Limburg",
                    IsActief = true
                };
            }
            if (planbaarDoorTeamsIds == default)
            {
                planbaarDoorTeamsIds = new List<int> { 1 };
            }
            if (boekjaren == default)
            {
                boekjaren = new List<DomainModelBoekjaar>
                {
                    new DomainModelBoekjaar
                    {
                        Id = 1,
                        Budget = 1000,
                        Jaar = 2025,
                        KlantId = 1
                    }
                };
            }

            return new EditKlantCommand(
                id,
                naam,
                startDatum,
                eindDatum,
                verantwoordelijkTeamId,
                medewerkerId,
                verantwoordelijkTeam,
                planbaarDoorTeamsIds,
                boekjaren
            );
        }

        // Controleer dat het bewerken van een klant een error teruggeeft als Naam korter is dan 2 karakters
        [Fact]
        public async Task EditKlantCommand_ReturnsError_WhenNameIsShorterThanTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new KlantController(mockMediator.Object);

            var command = CreateEditCommand(naam: "a");

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het bewerken van een klant een error teruggeeft als Naam langer is dan 100 karakters
        [Fact]
        public async Task EditKlantCommand_ReturnsError_WhenNameIsLongerThanHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new KlantController(mockMediator.Object);

            string longName = new string('a', 101);
            var command = CreateEditCommand(naam: longName);

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het bewerken van een klant geen error teruggeeft als Naam exact 2 karakters is
        [Fact]
        public async Task EditKlantCommand_ReturnsOK_WhenNameIsExactlyTwoCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<EditKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("", true));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateEditCommand(naam: "aa");

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het bewerken van een klant geen error teruggeeft als Naam exact 100 karakters is
        [Fact]
        public async Task EditKlantCommand_ReturnsOK_WhenNameIsExactlyHundredCharacters()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<EditKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("", true));

            var controller = new KlantController(mockMediator.Object);

            string longName = new string('a', 100);
            var command = CreateEditCommand(naam: longName);

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het bewerken van een klant een error teruggeeft als Startdatum in het verleden ligt
        [Fact]
        public async Task EditKlantCommand_ReturnsError_WhenStartDateIsInPast()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new KlantController(mockMediator.Object);

            var command = CreateEditCommand(startDatum: DateTime.Today.AddDays(-1));

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het bewerken van een klant geen error teruggeeft als Startdatum vandaag is
        [Fact]
        public async Task EditKlantCommand_ReturnsOK_WhenStartDateIsToday()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<EditKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("", true));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateEditCommand(startDatum: DateTime.Today);

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het bewerken van een klant geen error teruggeeft als Startdatum in de toekomst ligt
        [Fact]
        public async Task EditKlantCommand_ReturnsOK_WhenStartDateInFuture()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<EditKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("", true));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateEditCommand(startDatum: DateTime.Today.AddDays(1));

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het bewerken van een klant een error teruggeeft als Einddatum vóór de Startdatum ligt
        [Fact]
        public async Task EditKlantCommand_ReturnsError_WhenEndDateBeforeStartDate()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new KlantController(mockMediator.Object);

            var command = CreateEditCommand(startDatum: DateTime.Today, eindDatum: DateTime.Today.AddDays(-1));

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.NotEqual((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        // Controleer dat het bewerken van een klant geen error teruggeeft als Einddatum na de Startdatum ligt
        [Fact]
        public async Task EditKlantCommand_ReturnsOK_WhenEndDateAfterStartDate()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(med => med.Send(It.IsAny<EditKlantCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse("", true));

            var controller = new KlantController(mockMediator.Object);

            var command = CreateEditCommand(startDatum: DateTime.Today, eindDatum: DateTime.Today.AddDays(1));

            // Act
            var result = await controller.Update(command);

            // Assert
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}
