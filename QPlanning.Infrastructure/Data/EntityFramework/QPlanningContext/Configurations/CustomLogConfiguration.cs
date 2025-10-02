using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities.Logging;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class CustomLogConfiguration : IEntityTypeConfiguration<CustomLog>
    {
        public void Configure(EntityTypeBuilder<CustomLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("CustomLogging", "logging");    
        }
    }
}