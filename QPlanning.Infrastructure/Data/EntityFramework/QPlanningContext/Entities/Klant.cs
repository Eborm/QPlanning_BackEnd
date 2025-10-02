using System;
using System.Collections.Generic;
using QPlanning.Business.Domain.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities
{
    public class Klant : BaseEntity
    {
        public string Naam { get; set; }
        public DateTime? Startdatum { get; set; }
        public DateTime? Einddatum { get; set; }
        public int VerantwoordelijkTeamId { get; set; }
        public int MedewerkerId { get; set; }
      
        #region navigation properties
            /// <summary>
            /// User with the role Partner can only be added to be responsible for this Client.
            /// </summary>
            public Medewerker Partner { get; set; }
            /// <summary>
            /// The team that is responsible for the customer.
            /// </summary>
            public Team VerantwoordelijkTeam { get; set; }
            public virtual ICollection<KlantPlanbaarDoorTeams> PlanbaarDoorTeams { get; set; }
            
            public virtual ICollection<Boekjaar> Boekjaren { get; set; }
        #endregion
    }
}