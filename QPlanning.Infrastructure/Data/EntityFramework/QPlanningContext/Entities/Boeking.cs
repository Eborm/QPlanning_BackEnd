using System;
using QPlanning.Business.Domain.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities
{
    public class Boeking : BaseEntity
    {
        public int? Jaar { get; set; }
        public int? Boekjaar { get; set; }
        public int? Maand { get; set; }
        public int? Weeknummer { get; set; }
        public int? EersteDagVanDeWeek { get; set; }
        public DateTime Datum { get; set; }
        public int Uren { get; set; }
        public int MedewerkerId { get; set; }
        public int? KlantId { get; set; }
        public int? OpdrachtId { get; set; }
        public int? IndirecteUrenId { get; set; }
        public bool IsIndirect { get; set; }
        public bool MoetNogGeplandWorden { get; set; }
       
        #region navigation properties
        /// <summary>
        /// Eventuele Externe Medewerker die geboekt staat
        /// </summary>
        public Medewerker Medewerker { get; set; }
        /// <summary>
        /// De klant waarop geboekt wordt voor dit record
        /// </summary>
        public Klant Klant { get; set; }
        /// <summary>
        /// De opdracht waarvoor deze boeking gepland staat (meer diepgang dan alleen Klant)
        /// </summary>
        public Opdracht Opdracht { get; set; }
        /// <summary>
        /// Indien indirecte uren gemaakt worden in plaats van de klant zelf.
        /// </summary>
        public IndirecteUren IndirecteUren { get; set; }
        #endregion
    }
}