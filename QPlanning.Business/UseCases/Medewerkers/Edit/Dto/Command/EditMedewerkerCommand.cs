using System.Collections.Generic;
using MediatR;
using QPlanning.Business.Interfaces.Base;

namespace QPlanning.Business.UseCases.Medewerkers.Edit.Dto.Command
{
    public class EditMedewerkerCommand: IRequest<UseCaseResponseMessage>
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string TussenVoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public int? Tarief { get; set; }
        public int? InternTarief { get; set; }
        public int? MedewerkerFunctieId { get; set; }
        
        public bool IsActief { get; set; }
        
        public List<int> PlanbaarDoorTeamIds { get; set; }
        public int TeamId { get; set; }
    }
}