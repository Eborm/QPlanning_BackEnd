namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities
{
    public class Opdracht : BaseEntity
    {
        public string Omschrijving { get; set; }
        public bool IsActief { get; set; }
    }
}