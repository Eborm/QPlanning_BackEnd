using System.Collections.Generic;
using MediatR;
using QPlanning.Business.Interfaces.Base;

namespace QPlanning.Business.UseCases.Medewerkers.Add.Dto.Command
{
    public class AddMedewerkerCommand : IRequest<UseCaseResponseMessage>
    {
        public string Voornaam { get; set; }
        public string TussenVoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public int? Tarief { get; set; }
        public int? InternTarief { get; set; }
        public int? MedewerkerFunctieId { get; set; }
        
        public List<int> PlanbaarDoorTeamIds { get; set; }
        public int TeamId { get; set; }

        public AddMedewerkerCommand(string voornaam, string achternaam, string tussenVoegsel, string email, int tarief, int internTarief)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            TussenVoegsel = tussenVoegsel;
            Email = email;
            Tarief = tarief;
            InternTarief = internTarief;
        }
    }
}