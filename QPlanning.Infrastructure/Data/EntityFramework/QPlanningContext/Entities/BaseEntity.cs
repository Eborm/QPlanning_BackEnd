using System;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities.Interface;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities
{
	public class BaseEntity : IBaseEntitiy
	{
		public int Id { get; set; }
		public DateTime Created { get; set; }
		public string CreatedBy { get; set; }
		public DateTime Modified { get; set; }
		public string ModifiedBy { get; set; }
	}
}
