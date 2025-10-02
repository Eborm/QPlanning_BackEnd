using System;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities.Logging
{
    public class ExceptionLog
    {
        public int Id { get; set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public string RequestHost { get; set; }
        public string ExceptionLogMessage { get; set; }
        public string HeaderInfo { get; set; }
        public string ContextUser { get; set; }
    }
}