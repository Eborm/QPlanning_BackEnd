namespace QPlanning.Business.Domain.Entities
{
    public class DomainModelMedewerkerPlanbaarDoorTeams
    {
        public int MedewerkerId { get; set; }
        public DomainModelMedewerker Medewerker { get; set; }
        public int TeamId { get; set; }
        public DomainModelTeam Team { get; set; }
    }
}