using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class OpdrachtConfiguration : IEntityTypeConfiguration<Opdracht>
    {
        public void Configure(EntityTypeBuilder<Opdracht> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Opdracht", "dbo");

            builder.HasData(
                new Opdracht{Id = 1, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Omschrijving = "Interim", IsActief = true},
                new Opdracht{Id = 2, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Omschrijving = "Balanscontrole", IsActief = true},
                new Opdracht{Id = 3, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Omschrijving = "Inventarisatie", IsActief = true},
                new Opdracht{Id = 4, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Omschrijving = "Bijzondere verklaringen", IsActief = true},
                new Opdracht{Id = 5, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Omschrijving = "Overig", IsActief = true}
            );
        }
    }
}