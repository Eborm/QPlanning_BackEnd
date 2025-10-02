using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class MedewerkerConfiguration: IEntityTypeConfiguration<Medewerker>
    {
        public void Configure(EntityTypeBuilder<Medewerker> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Medewerker", "dbo");
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasOne(x => x.MedewerkerFunctie).WithMany().HasForeignKey(x => x.MedewerkerFunctieId);
            builder.HasOne(x => x.Team).WithMany().HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.Restrict);
        }
        
    }
}