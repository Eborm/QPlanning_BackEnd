using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Business.Extensions.Middleware;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities.Logging;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("ExceptionLogging", "logging");    
        }
    }
}