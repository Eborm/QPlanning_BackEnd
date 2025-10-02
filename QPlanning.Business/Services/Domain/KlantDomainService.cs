using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.GatewayReponses;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.UseCases.Klanten.Add.Dto.Commands;
using QPlanning.Business.UseCases.Klanten.Edit.Dto.Commands;

namespace QPlanning.Business.Services.Domain
{
    public class KlantDomainService : IKlantDomainService
    {
        private readonly IKlantService _klantService;
        private readonly ITeamService _teamService;

        public KlantDomainService(IKlantService klantService, ITeamService teamService)
        {
            _klantService = klantService;
            _teamService = teamService;
        }
        

        public async Task<BaseResponse> AddKlant(AddKlantCommand klant)
        {
            var domainModelKlant = new DomainModelKlant
            {
                Naam = klant.Naam,
                Startdatum = klant.Startdatum,
                Einddatum = klant.Einddatum,
                MedewerkerId = klant.MedewerkerId,
                VerantwoordelijkTeamId = klant.VerantwoordelijkTeamId,
                Boekjaren = new List<DomainModelBoekjaar>
                {
                    new DomainModelBoekjaar
                    {
                        Jaar = klant.Boekjaar,
                        Budget = klant.Budget
                    }
                }
            };
            
            var teams = await _teamService.GetTeams();
            if (klant.PlanbaarDoorTeamIds != null)
            {
                var selectedPlanbaarTeams = teams.Where(x => klant.PlanbaarDoorTeamIds.Contains(x.Id));
                domainModelKlant.PlanbaarDoorTeams = selectedPlanbaarTeams.Select(planbaarTeam => new DomainModelKlantPlanbaarDoorTeams {Klant = domainModelKlant, TeamId = planbaarTeam.Id}).ToList();
            }

            var klantResult = await _klantService.AddKlant(domainModelKlant);
            return new BaseResponse(klantResult.Id, klantResult.Success, $"Het toevoegen van de nieuwe klant is gelukt.");
        }

        public async Task<BaseResponse> EditKlant(EditKlantCommand klantCommand)
        {
            var klant = new DomainModelKlant
            {
                Id = klantCommand.Id,
                Naam = klantCommand.Naam,
                Startdatum = klantCommand.Startdatum,
                Einddatum = klantCommand.Einddatum,
                MedewerkerId = klantCommand.MedewerkerId,
                VerantwoordelijkTeamId = klantCommand.VerantwoordelijkTeamId,
            };
            var verantwoordelijkTeamsFrontend = klantCommand.PlanbaarDoorTeamIds.Select(teamId => new DomainModelKlantPlanbaarDoorTeams {KlantId = klantCommand.Id, TeamId = teamId}).ToList();
           
            klant.PlanbaarDoorTeams = verantwoordelijkTeamsFrontend;

            var klantResult = await _klantService.EditKlant(klant);
            return new BaseResponse(klantResult.Id, klantResult.Success, $"Het wijzigen van de klant is gelukt.");
        }
    }
}