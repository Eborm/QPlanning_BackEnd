using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Models.Dropdown;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.UseCases.Boeking.Get.Dto;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Responses;
using QPlanning.Business.UseCases.Klanten.Get.Models;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Response;
using QPlanning.Business.UseCases.Teams.Get.Dto.Response;

namespace QPlanning.Business.Services.Domain
{
    public class QPlanningDomainService : IQPlanningDomainService
    {
        private readonly IKlantService _klantService;
        private readonly IMedewerkerRepository _medewerkerRepository;
        private readonly IOpdrachtRepository _opdrachtRepository;
        private readonly IIndirecteUrenRepository _indirecteUrenRepository;
        private readonly IMedewerkerFunctieRepository _medewerkerFunctieRepository;
        private readonly ITeamRepository _teamRepository;

        public QPlanningDomainService(IKlantService klantService, IMedewerkerRepository medewerkerRepository,
            IOpdrachtRepository opdrachtRepository, IIndirecteUrenRepository indirecteUrenRepository,
            IMedewerkerFunctieRepository medewerkerFunctieRepository, ITeamRepository teamRepository)
        {
            _klantService = klantService;
            _medewerkerRepository = medewerkerRepository;
            _opdrachtRepository = opdrachtRepository;
            _indirecteUrenRepository = indirecteUrenRepository;
            _medewerkerFunctieRepository = medewerkerFunctieRepository;
            _teamRepository = teamRepository;
        }

        public async Task<BoekingDropDownResponse> GetBoekingDropDownValues(string email)
        {
            var medewerkers = await _medewerkerRepository.GetMedewerkers();
            var currentLoggedInMedewerker = medewerkers.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));

            if (currentLoggedInMedewerker == null) return new BoekingDropDownResponse();

            var teamId = currentLoggedInMedewerker.Team.Id;
            var klanten = await _klantService.GetKlantenForTeam(teamId);

            var indirecteUren = await _indirecteUrenRepository.GetIndirecteUren();
            var opdrachten = await _opdrachtRepository.GetOpdrachten();
            var teams = await _teamRepository.GetTeams();

            var boekingDropDownResponse = new BoekingDropDownResponse
            {
                KlantDropDown = klanten
                    .Select(k => new DropDown
                    {
                        Id = k.Id,
                        Naam = k.Naam
                    }).OrderBy(x => x.Naam).ToList(),
                MedewerkerDropDown = medewerkers
                    .Where(x => x.TeamId == teamId || x.PlanbaarDoorTeams.Any(y => y.TeamId == teamId))
                    .Select(m => new DropDown
                    {
                        Id = m.Id,
                        Naam = $"{m.Voornaam} {m.TussenVoegsel} {m.Achternaam}"
                    }).OrderBy(x => x.Naam).ToList(),
                IndirecteUrenDropDown = indirecteUren.Select(i => new DropDown
                {
                    Id = i.Id,
                    Naam = i.Omschrijving
                }).OrderBy(x => x.Naam).ToList(),
                OpdrachtDropDown = opdrachten.Select(o => new DropDown
                {
                    Id = o.Id,
                    Naam = o.Omschrijving
                }).OrderBy(x => x.Naam).ToList(),
                TeamDropDown = teams.Select(t => new DropDown
                {
                    Id = t.Id,
                    Naam = t.Naam
                }).ToList(),
                InitialSelectedTeam = teamId
            };

            return boekingDropDownResponse;
        }

        public async Task<MedewerkerDropDownResponse> GetMedewerkerDropDownValues()
        {
            var functies = await _medewerkerFunctieRepository.GetMedewerkerFuncties();
            var teams = await _teamRepository.GetTeams();

            var medewerkerDropDownResponse = new MedewerkerDropDownResponse
            {
                TeamDropDown = teams.Select(i => new DropDown
                {
                    Id = i.Id,
                    Naam = i.Naam
                }).OrderBy(x => x.Naam).ToList(),
                MedewerkerFunctieDropDown = functies.Select(i => new DropDown
                {
                    Id = i.Id,
                    Naam = i.DisplayName
                }).OrderBy(x => x.Naam).ToList(),
            };

            return medewerkerDropDownResponse;
        }

        public async Task<GetKlantDropDownResponse> GetKlantDropDownValues(string email)
        {
            var medewerkers = await _medewerkerRepository.GetMedewerkers();
            var currentLoggedInMedewerker = medewerkers.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
            var teams = await _teamRepository.GetTeams();
            var opdrachten = await _opdrachtRepository.GetOpdrachten();

            if (currentLoggedInMedewerker == null) return new GetKlantDropDownResponse();

            var newKlantDropDownResponse = new GetKlantDropDownResponse
            {
                MedewerkerDropDown = medewerkers
                    .Where(x => x.MedewerkerFunctie?.TechnischeNaam == "Partner" ||  x.MedewerkerFunctie?.TechnischeNaam == "Manager") 
                    .Select(i => new DropDown
                    {
                        Id = i.Id,
                        Naam = $"{i.Voornaam} {i.TussenVoegsel} {i.Achternaam}"
                    }).OrderBy(x => x.Naam).ToList(),
                TeamDropDown = teams.Select(i => new DropDown
                {
                    Id = i.Id,
                    Naam = i.Naam
                }).OrderBy(x => x.Naam).ToList(),
                OpdrachtDropDown = opdrachten
                    .Select(i => new DropDown
                    {
                        Id = i.Id,
                        Naam = i.Omschrijving
                    }).OrderBy(x => x.Naam).ToList()
            };

            return newKlantDropDownResponse;
        }

        public async Task<GetKlantenResponse> GetKlantenForTeam(string email)
        {
            var gebruiker = _medewerkerRepository.GetDomainModelMedewerker(email);
            var klanten = await _klantService.GetKlantenForTeam(null);
            var klantenResponse = new GetKlantenResponse
            {
                Klanten = new List<KlantDisplayModel>()
            };
            foreach (var klant in klanten)
            {
                klantenResponse.Klanten.Add(
                    new KlantDisplayModel
                    {
                        Id = klant.Id,
                        MedewerkerId = klant.MedewerkerId,
                        VerantwoordelijkTeamId = klant.VerantwoordelijkTeamId,
                        Naam = klant.Naam,
                        MedewerkerNaam =
                            $"{klant.Partner?.Voornaam} {klant.Partner?.TussenVoegsel} {klant.Partner?.Achternaam}",
                        VerantwoordelijkTeamNaam = klant.VerantwoordelijkTeam.Naam,
                        Boekjaren = klant.Boekjaren.ToList(),
                        Startdatum = klant.Startdatum,
                        Einddatum = klant.Einddatum,
                        PlanbaarDoorTeamIds = klant.PlanbaarDoorTeams?.Select(x => x.TeamId).ToList(),
                        PlandbaarDoorTeamNamen = klant.PlanbaarDoorTeams?.Select(x => x.Team.Naam).ToList()
                    }
                );
            }

            return klantenResponse;
        }
        
        public async Task<TeamDropDownResponse> GetTeamDropDownValues(string email)
        {
            var medewerkers = await _medewerkerRepository.GetMedewerkers();
            var currentLoggedInMedewerker = medewerkers.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));

            if (currentLoggedInMedewerker == null) return new TeamDropDownResponse();

            var teamId = currentLoggedInMedewerker.Team.Id;
            var teams = await _teamRepository.GetTeams();
            var klanten = await _klantService.GetKlantenForTeam(null);
           

            var teamDropDownResponse = new TeamDropDownResponse()
            {
                InitialSelectedTeamId = teamId,
                TeamDropDown = teams.Select(i => new DropDown
                {
                    Id = i.Id,
                    Naam = i.Naam
                }).OrderBy(x => x.Naam).ToList(),
                KlantDropDown = klanten.Select(i => new DropDown
                {
                    Id = i.Id,
                    Naam = i.Naam
                }).OrderBy(x => x.Naam).ToList(),
                MedewerkerDropDown = medewerkers.Select(i => new DropDown
                {
                    Id = i.Id,
                    Naam = $"{i.Voornaam} {i.TussenVoegsel} {i.Achternaam}"
                }).OrderBy(x => x.Naam).ToList(),
            };

            return teamDropDownResponse;
        }
    }
}