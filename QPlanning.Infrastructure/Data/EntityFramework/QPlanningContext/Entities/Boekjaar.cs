namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities
{
    public class Boekjaar : BaseEntity
    {
        public int KlantId { get; set; }
        public int Jaar { get; set; }
        public int Budget { get; set; }
    }
}