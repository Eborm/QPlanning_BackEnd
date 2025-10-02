using System.Collections.Generic;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities
{
    public class Medewerker : BaseEntity
    {
        public string Voornaam { get; set; }
        public string TussenVoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public int? Tarief { get; set; }
        public int? InternTarief { get; set; }
        public int? MedewerkerFunctieId { get; set; }
        
        public int TeamId { get; set; }

        public bool IsActief { get; set; }

        #region navigation properties
        public MedewerkerFunctie MedewerkerFunctie { get; set; }

        public Team Team { get; set; }
        
        public virtual ICollection<MedewerkerPlanbaarDoorTeams> PlanbaarDoorTeams { get; set; }
        #endregion
    }
}