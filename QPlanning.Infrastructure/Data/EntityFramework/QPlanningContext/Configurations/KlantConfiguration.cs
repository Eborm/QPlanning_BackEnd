using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class KlantConfiguration: IEntityTypeConfiguration<Klant>
    {
        public void Configure(EntityTypeBuilder<Klant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Klant", "dbo");
            builder.HasOne(x => x.Partner).WithMany().HasForeignKey(x => x.MedewerkerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.VerantwoordelijkTeam).WithMany().HasForeignKey(x => x.VerantwoordelijkTeamId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Boekjaren).WithOne().HasForeignKey(x => x.KlantId).OnDelete(DeleteBehavior.Restrict);
        }
        
    }
}