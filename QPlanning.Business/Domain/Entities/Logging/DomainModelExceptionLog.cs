namespace QPlanning.Business.Domain.Entities.Logging
{
    public class DomainModelExceptionLog
    {
        public string RequestHost { get; set; }
        public string ExceptionLogMessage { get; set; }
        public string HeaderInfo { get; set; }
        public string ContextUser { get; set; }
    }
}