using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Medewerkers.Add.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Edit.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Models;

namespace QPlanning.Business.Services
{
    public class MedewerkerService : IMedewerkerService
    {
        private readonly IMedewerkerRepository _medewerkerRepository;
        
        private readonly ITeamService _teamService;

        public MedewerkerService(IMedewerkerRepository medewerkerRepository, ITeamService teamService)
        {
            _medewerkerRepository = medewerkerRepository;
            _teamService = teamService;
        }

        public async Task<IList<MedewerkerViewModel>> GetMedewerkers()
        {
            var medewerkerList = await _medewerkerRepository.GetMedewerkers() ?? new List<DomainModelMedewerker>();
            
            var medewerkerVieModelList = new List<MedewerkerViewModel>();
            foreach (var medewerker in medewerkerList)
            {
                var medewerkerViewModel = new MedewerkerViewModel
                {
                    Voornaam = medewerker.Voornaam,
                    Achternaam = medewerker.Achternaam,
                    Email = medewerker.Email,
                    Id = medewerker.Id,
                    Tarief = medewerker.Tarief,
                    InternTarief = medewerker.InternTarief,
                    IsActief = medewerker.IsActief,
                    TeamId = medewerker.TeamId,
                    TeamNaam = medewerker.Team.Naam,
                    TussenVoegsel = medewerker.TussenVoegsel,
                    MedewerkerFunctieId = medewerker.MedewerkerFunctieId,
                    PlanbaarDoorTeamIds = medewerker.PlanbaarDoorTeams?.Select(x => x.TeamId).ToList(),
                    PlandbaarDoorTeamNamen = medewerker.PlanbaarDoorTeams?.Select(x => x.Team.Naam).ToList(),
                    MedewerkerFunctieNaam = medewerker.MedewerkerFunctie?.DisplayName
                };
                medewerkerVieModelList.Add(medewerkerViewModel);
            }
            
            return medewerkerVieModelList;
        }

        public async Task<BaseResponse> AddMedewerker(AddMedewerkerCommand addMedewerkerCommand)
        {
            var domainModelMedewerker = new DomainModelMedewerker
            {
                Achternaam =  addMedewerkerCommand.Achternaam,
                Email = addMedewerkerCommand.Email,
                Tarief = addMedewerkerCommand.Tarief,
                Voornaam = addMedewerkerCommand.Voornaam,
                InternTarief = addMedewerkerCommand.InternTarief,
                IsActief = true,
                TeamId = addMedewerkerCommand.TeamId,
                TussenVoegsel = addMedewerkerCommand.TussenVoegsel,
                MedewerkerFunctieId = addMedewerkerCommand.MedewerkerFunctieId
            };
            
            var teams = await _teamService.GetTeams();
            if (addMedewerkerCommand.PlanbaarDoorTeamIds != null)
            {
                var selectedPlanbaarTeams = teams.Where(x => addMedewerkerCommand.PlanbaarDoorTeamIds.Contains(x.Id));
                domainModelMedewerker.PlanbaarDoorTeams = selectedPlanbaarTeams.Select(planbaarTeam => new DomainModelMedewerkerPlanbaarDoorTeams() {Medewerker = domainModelMedewerker, TeamId = planbaarTeam.Id}).ToList();
            }

            var result = await _medewerkerRepository.AddMedewerker(domainModelMedewerker);
            return new BaseResponse (result.Id, result.Success, $"Het toevoegen van het de nieuwe medewerker is gelukt.");

        }

        public async Task<BaseResponse> EditMewerker(EditMedewerkerCommand editMedewerkerCommand)
        {
            var domainModelMedewerker = new DomainModelMedewerker
            {
                Id =  editMedewerkerCommand.Id,
                Achternaam =  editMedewerkerCommand.Achternaam,
                Email = editMedewerkerCommand.Email,
                Tarief = editMedewerkerCommand.Tarief,
                Voornaam = editMedewerkerCommand.Voornaam,
                InternTarief = editMedewerkerCommand.InternTarief,
                IsActief = true,
                TeamId = editMedewerkerCommand.TeamId,
                TussenVoegsel = editMedewerkerCommand.TussenVoegsel,
                MedewerkerFunctieId = editMedewerkerCommand.MedewerkerFunctieId
            };

            var planbaarDoorTeams = editMedewerkerCommand.PlanbaarDoorTeamIds.Select(teamId => new DomainModelMedewerkerPlanbaarDoorTeams() {MedewerkerId = editMedewerkerCommand.Id, TeamId = teamId}).ToList();
            domainModelMedewerker.PlanbaarDoorTeams = planbaarDoorTeams;

            var result = await _medewerkerRepository.EditMewewerker(domainModelMedewerker);
            return new BaseResponse (result.Id, result.Success, $"Het bijwerken van de medewerker is gelukt.");
        }

        public async Task<BaseResponse> ToggleActiveMedwerker(int id, bool shouldBeActive)
        {
            var result = await _medewerkerRepository.ToggleActiveMedwerker(id, shouldBeActive);

            var message = "De medewerker is gedeactiveerd.";
            if (shouldBeActive)
                message = "De medewerker is geactiveerd.";
            
            return new BaseResponse (result.Id, result.Success, message);
        }
    }
}