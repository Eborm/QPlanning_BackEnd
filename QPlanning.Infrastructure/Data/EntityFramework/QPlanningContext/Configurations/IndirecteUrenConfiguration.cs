using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class IndirecteUrenConfiguration : IEntityTypeConfiguration<IndirecteUren>
    {
        public void Configure(EntityTypeBuilder<IndirecteUren> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("IndirecteUren", "dbo");

            builder.HasData(
                    new IndirecteUren { Id = 1 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Feestdag", IsActief = true},
                    new IndirecteUren { Id = 2 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Interne Projecten", IsActief = true},
                    new IndirecteUren { Id = 3 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Overig", IsActief = true},
                    new IndirecteUren { Id = 4 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Parttime", IsActief = true},
                    new IndirecteUren { Id = 5 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Regulier verlof", IsActief = true},
                    new IndirecteUren { Id = 6 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Studie", IsActief = true},
                    new IndirecteUren { Id = 7 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Ziek", IsActief = true},
                    new IndirecteUren { Id = 8 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Vaktechniek", IsActief = true},
                    new IndirecteUren { Id = 9 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Marcom", IsActief = true},
                    new IndirecteUren { Id = 10 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Zwangerschapsverlof", IsActief = true},
                    new IndirecteUren { Id = 11 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "QAS", IsActief = true},
                    new IndirecteUren { Id = 12 , Created =  new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM", Omschrijving = "Nog niet in dienst", IsActief = true}
                    );
        }
        
    }
}