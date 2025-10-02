using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Configurations
{
    public class MedewerkerFunctieConfiguration: IEntityTypeConfiguration<MedewerkerFunctie>
    {
        public void Configure(EntityTypeBuilder<MedewerkerFunctie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("MedewerkerFunctie", "dbo");

            builder.HasData(
                new MedewerkerFunctie{Id = 1, TechnischeNaam = "Partner", DisplayName = "Partner", Beschrijving = "Deze persoon heeft de functie Partner"},
                new MedewerkerFunctie{Id = 2, TechnischeNaam = "Manager", DisplayName = "Manager", Beschrijving = "Deze persoon heeft de functie Manager"},
                new MedewerkerFunctie{Id = 3, TechnischeNaam = "AssistantManager", DisplayName = "Assistant manager", Beschrijving = "Deze persoon heeft de functie AssistantManager"},
                new MedewerkerFunctie{Id = 4, TechnischeNaam = "SeniorAssociate", DisplayName = "Senior associate", Beschrijving = "Deze persoon heeft de functie Senior associate"},
                new MedewerkerFunctie{Id = 5, TechnischeNaam = "Associate", DisplayName = "Associate", Beschrijving = "Deze persoon heeft de functie Associate"},
                new MedewerkerFunctie{Id = 6, TechnischeNaam = "Stagiair", DisplayName = "Stagiair", Beschrijving = "Deze persoon heeft de functie Stagiair"},
                new MedewerkerFunctie{Id = 7, TechnischeNaam = "Inhuur", DisplayName = "Inhuur", Beschrijving = "Inhuur van een persoon, dit kan ook vanuit een ander team zijn"},
                new MedewerkerFunctie{Id = 8, TechnischeNaam = "Extern", DisplayName = "Extern", Beschrijving = "Inhuur van een Externe functie"},
                new MedewerkerFunctie{Id = 9, TechnischeNaam = "IT", DisplayName = "IT Digle", Beschrijving = "Inhuur van een IT functie"},
                new MedewerkerFunctie{Id = 10, TechnischeNaam = "PlaceHolder", DisplayName = "PlaceHolder", Beschrijving = "Dit is een tijdelijke toekenning waarna een definitieve kan volgen"}
            );
        }
    }
}