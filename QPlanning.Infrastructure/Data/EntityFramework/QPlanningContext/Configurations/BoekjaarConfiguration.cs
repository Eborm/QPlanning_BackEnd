using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities.Logging;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class BoekjaarConfiguration: IEntityTypeConfiguration<Boekjaar>
    {
        public void Configure(EntityTypeBuilder<Boekjaar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Boekjaar", "dbo");
            
            builder.HasAlternateKey(c => new {c.KlantId, c.Jaar}).HasName("IX_UniqueConstraint_KlantId_Jaar");
            builder.HasIndex(p => new { p.KlantId, p.Jaar }).IsClustered(false).IsUnique().HasName("IX_NonClustered_KlantId_Jaar");;
        }
    }
}