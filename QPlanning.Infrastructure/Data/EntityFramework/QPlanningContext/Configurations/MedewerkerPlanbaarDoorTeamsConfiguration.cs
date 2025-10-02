using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class MedewerkerPlanbaarDoorTeamsConfiguration: IEntityTypeConfiguration<MedewerkerPlanbaarDoorTeams>
    {
        public void Configure(EntityTypeBuilder<MedewerkerPlanbaarDoorTeams> builder)
        {
            builder.HasKey(kpt => new {kpt.MedewerkerId, kpt.TeamId});
            builder.ToTable("MedewerkerPlanbaarDoorTeams", "dbo");
            
            builder.HasOne(bc => bc.Medewerker)
                .WithMany(b => b.PlanbaarDoorTeams)
                .HasForeignKey(bc => bc.MedewerkerId);  
            builder.HasOne(bc => bc.Team)
                .WithMany(c => c.MedewerkerPlanbaarDoorTeams)
                .HasForeignKey(bc => bc.TeamId);
        }
    }
}