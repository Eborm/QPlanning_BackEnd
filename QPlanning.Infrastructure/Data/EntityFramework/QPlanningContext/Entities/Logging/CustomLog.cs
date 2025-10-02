using System;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities.Logging
{
    public class CustomLog
    {
        public int Id { get; set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public string Level { get; set; }
        public string Message { get; set; }
        public string RequestObjectName { get; set; }
        public string RequestJsonObject { get; set; }
        public string DestinationObjectName { get; set; }
    }
}