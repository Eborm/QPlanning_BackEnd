using System;
using System.Collections.Generic;

namespace QPlanning.Business.Domain.Entities
{
    public class DomainModelKlant
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime? Startdatum { get; set; }
        public DateTime? Einddatum { get; set; }
        public int VerantwoordelijkTeamId { get; set; }
        public int MedewerkerId { get; set; }
        
        #region navigation properties
        /// <summary>
        /// User with the role Partner can only be added to be responsible for this Client.
        /// </summary>
        public DomainModelMedewerker Partner { get; set; }
        /// <summary>
        /// The team that is responsible for the customer.
        /// </summary>
        public DomainModelTeam VerantwoordelijkTeam { get; set; }
        public IEnumerable<DomainModelKlantPlanbaarDoorTeams> PlanbaarDoorTeams { get; set; }
        
        public IEnumerable<DomainModelBoekjaar> Boekjaren { get; set; }
        #endregion
    }
}