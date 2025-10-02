using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class BoekingConfiguration : IEntityTypeConfiguration<Boeking>
    {
        public void Configure(EntityTypeBuilder<Boeking> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Boeking", "dbo");
            builder.Property(b => b.Datum).HasDefaultValueSql("getdate()");
            builder.HasOne(x => x.Klant).WithMany().HasForeignKey(x => x.KlantId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Medewerker).WithMany().HasForeignKey(x => x.MedewerkerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Opdracht).WithMany().HasForeignKey(x => x.OpdrachtId);
            builder.HasOne(x => x.IndirecteUren).WithMany().HasForeignKey(x => x.IndirecteUrenId);
        }
    }
}