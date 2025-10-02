namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities
{
    public class MedewerkerPlanbaarDoorTeams
    {
        public int MedewerkerId { get; set; }
        public Medewerker Medewerker { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}