using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class KlantPlanbaarDoorTeamsConfiguration: IEntityTypeConfiguration<KlantPlanbaarDoorTeams>
    {
        public void Configure(EntityTypeBuilder<KlantPlanbaarDoorTeams> builder)
        {
            builder.HasKey(kpt => new {kpt.KlantId, kpt.TeamId});
            builder.ToTable("KlantPlanbaarDoorTeams", "dbo");
            
            builder.HasOne(bc => bc.Klant)
                .WithMany(b => b.PlanbaarDoorTeams)
                .HasForeignKey(bc => bc.KlantId);  
            builder.HasOne(bc => bc.Team)
                .WithMany(c => c.KlantPlanbaarDoorTeams)
                .HasForeignKey(bc => bc.TeamId);
        }
    }
}