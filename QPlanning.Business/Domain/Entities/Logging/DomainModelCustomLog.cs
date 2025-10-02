namespace QPlanning.Business.Domain.Entities.Logging
{
    public class DomainModelCustomLog
    {
        public string Level { get; set; }
        public string Message { get; set; }
        public string RequestObjectName { get; set; }
        public string RequestJsonObject { get; set; }
        public string DestinationObjectName { get; set; }
    }
}