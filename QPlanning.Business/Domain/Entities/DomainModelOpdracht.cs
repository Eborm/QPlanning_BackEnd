namespace QPlanning.Business.Domain.Entities
{
    public class DomainModelOpdracht
    {
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public bool IsActief { get; set; }
    }
}