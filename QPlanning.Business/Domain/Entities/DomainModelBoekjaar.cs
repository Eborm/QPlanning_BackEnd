namespace QPlanning.Business.Domain.Entities
{
    public class DomainModelBoekjaar
    {
        public int Id { get; set; }
        public int KlantId { get; set; }
        public int Jaar { get; set; }
        public int Budget { get; set; }
    }
}