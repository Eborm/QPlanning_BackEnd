namespace QPlanning.Business.Domain.Entities
{
    public class DomainModelKlantPlanbaarDoorTeams
    {
        public int KlantId { get; set; }
        public DomainModelKlant Klant { get; set; }
        public int TeamId { get; set; }
        public DomainModelTeam Team { get; set; }
    }
}