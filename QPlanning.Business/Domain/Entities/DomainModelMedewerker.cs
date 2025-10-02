using System.Collections.Generic;

namespace QPlanning.Business.Domain.Entities
{
    public class DomainModelMedewerker
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string TussenVoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public int? Tarief { get; set; }
        public int? InternTarief { get; set; }
        public int? MedewerkerFunctieId { get; set; }
        
        public IEnumerable<DomainModelMedewerkerPlanbaarDoorTeams> PlanbaarDoorTeams { get; set; }
        public bool IsActief { get; set; }
        
        public int TeamId { get; set; }

        #region navigation properties
        public DomainModelMedewerkerFunctie MedewerkerFunctie { get; set; }

        public DomainModelTeam Team { get; set; }
        #endregion
    }
}