using System;
using System.Collections.Generic;
using MediatR;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.GatewayReponses;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.UseCases.Klanten.Edit.Dto.Commands
{
    public class EditKlantCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime? Startdatum { get; set; }
        public DateTime? Einddatum { get; set; }
        public int VerantwoordelijkTeamId { get; set; }
        public int MedewerkerId { get; set; }
        
        public DomainModelTeam VerantwoordelijkTeam { get; set; }
        public IEnumerable<int> PlanbaarDoorTeamIds { get; set; }
        public IEnumerable<DomainModelBoekjaar> Boekjaren { get; set; }

        public EditKlantCommand(int id, string naam, DateTime? startDatum, DateTime? eindDatum,
            int verantwoordelijkTeamId, int medewerkerId, DomainModelTeam verantwoordelijkTeam,
            IEnumerable<int> planbaarDoorTeamIds, IEnumerable<DomainModelBoekjaar> boekjaren)
        {
            Id = id;
            Naam = naam;
            Startdatum = startDatum;
            Einddatum = eindDatum;
            VerantwoordelijkTeamId = verantwoordelijkTeamId;
            MedewerkerId = medewerkerId;
            VerantwoordelijkTeam = verantwoordelijkTeam;
            PlanbaarDoorTeamIds = planbaarDoorTeamIds;
            Boekjaren = boekjaren;
        }
    }
}