using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class TeamsConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Team", "dbo");
            
            builder.HasData(
                new Team{Id = 1, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Naam = "Limburg", IsActief = true},
                new Team{Id = 2, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Naam = "Healthcare", IsActief = true},
                new Team{Id = 3, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Naam = "Den Bosch", IsActief = true},
                new Team{Id = 4, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Naam = "Rotterdam", IsActief = true},
                new Team{Id = 5, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Naam = "Arnhem", IsActief = true},
                new Team{Id = 6, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Naam = "Amsterdam", IsActief = true},
                new Team{Id = 7, Created = new DateTime(2019, 12, 7), CreatedBy = "RM", Modified = new DateTime(2019, 12, 7), ModifiedBy = "RM",Naam = "Woco", IsActief = true}
            );
        }
    }
}