namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities
{
    public class KlantPlanbaarDoorTeams
    {
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}