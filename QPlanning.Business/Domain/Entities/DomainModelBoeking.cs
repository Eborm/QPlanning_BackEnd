using System;

namespace QPlanning.Business.Domain.Entities
{
    public class DomainModelBoeking
    {
        public int Id { get; set; }
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
        public DomainModelMedewerker Medewerker { get; set; }
        /// <summary>
        /// De klant waarop geboekt wordt voor dit record
        /// </summary>
        public DomainModelKlant Klant { get; set; }
        /// <summary>
        /// De opdracht waarvoor deze boeking gepland staat (meer diepgang dan alleen Klant)
        /// </summary>
        public DomainModelOpdracht Opdracht { get; set; }
        /// <summary>
        /// Indien indirecte uren gemaakt worden in plaats van de klant zelf.
        /// </summary>
        public DomainModelIndirecteUren IndirecteUren { get; set; }
        #endregion
    }
}