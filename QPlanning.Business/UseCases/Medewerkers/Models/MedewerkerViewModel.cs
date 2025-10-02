using System.Collections.Generic;

namespace QPlanning.Business.UseCases.Medewerkers.Models
{
    public class MedewerkerViewModel
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string TussenVoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public int? Tarief { get; set; }
        public int? InternTarief { get; set; }
        public int? MedewerkerFunctieId { get; set; }
        
        public List<int> PlanbaarDoorTeamIds { get; set; }
        
        public bool IsActief { get; set; }
        
        public int TeamId { get; set; }

        public string MedewerkerFunctieNaam { get; set; }
        public string TeamNaam { get; set; }
        
        public List<string> PlandbaarDoorTeamNamen { get; set; }
    }
}