using System;
using System.Collections.Generic;
using QPlanning.Business.Domain.Entities;

namespace QPlanning.Business.UseCases.Klanten.Get.Models
{
    public class KlantDisplayModel
    {
        public int Id { get; set; }
        public int MedewerkerId { get; set; }
        public int VerantwoordelijkTeamId { get; set; }
        public string Naam { get; set; }
        public List<int> PlanbaarDoorTeamIds { get; set; }
        public List<DomainModelBoekjaar> Boekjaren { get; set; }
        public DateTime? Startdatum { get; set; }
        public DateTime? Einddatum { get; set; }
        public string MedewerkerNaam { get; set; }
        public string VerantwoordelijkTeamNaam { get; set; }
        public List<string> PlandbaarDoorTeamNamen { get; set; }
        
        
    }
}