using System.Collections.Generic;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities
{
    public class Team : BaseEntity
    {
        public string Naam { get; set; }
        public bool IsActief { get; set; }
        
        public virtual ICollection<KlantPlanbaarDoorTeams> KlantPlanbaarDoorTeams { get; set; }
        
        public virtual ICollection<MedewerkerPlanbaarDoorTeams> MedewerkerPlanbaarDoorTeams { get; set; }
    }
}