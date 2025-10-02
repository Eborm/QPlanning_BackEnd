using Microsoft.EntityFrameworkCore;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext;

namespace QPlanning.Infrastructure.Data.EntityFramework
{
	public class QPlanningDbContextFactory : DesignTimeDbContextFactoryBase<QPlanningApplicationContext>
	{
		protected override QPlanningApplicationContext CreateNewInstance(DbContextOptions<QPlanningApplicationContext> options)
		{
			return new QPlanningApplicationContext(options);
		}
	}
}
