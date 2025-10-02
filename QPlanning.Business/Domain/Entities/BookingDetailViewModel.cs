using System;
using Microsoft.VisualBasic;

namespace QPlanning.Business.Domain.Entities
{
    public class BookingDetailViewModel
    {
        public int Id { get; set; }
        public int MedewerkerId { get; set; }
        public int? KlantId { get; set; }
        public int? OpdrachtId { get; set; }
        public int? IndirecteUrenId { get; set; }
        public int? Jaar { get; set; }
        public int? Weeknummer { get; set; }
        public int Uren { get; set; }
        public string MedewerkerNaam { get; set; }
        public int? Boekjaar { get; set; }
        public string MedewerkerFunctie { get; set; }
        public string KlantNaam { get; set; }
        public string IndirecteUrenNaam { get; set; }
        public string OpdrachtNaam { get; set; }

        public string GeboektOp { get; set; }

        public string TeamNaam { get; set; }

        public bool CanBeEdited { get; set; }

        public DateTime PlannedDate{ get; set; }
    }
}