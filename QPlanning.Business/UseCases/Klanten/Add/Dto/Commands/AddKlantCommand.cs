using System;
using System.Collections.Generic;
using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;


namespace QPlanning.Business.UseCases.Klanten.Add.Dto.Commands
{
    public class AddKlantCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime? Startdatum { get; set; }
        public DateTime? Einddatum { get; set; }
        public int VerantwoordelijkTeamId { get; set; }
        public int MedewerkerId { get; set; }

        public List<int> PlanbaarDoorTeamIds { get; set; }

        public int Boekjaar { get; set; }
        public int Budget { get; set; }

        public AddKlantCommand(
            int id, string naam, DateTime? startDatum, DateTime? eindDatum, int verantwoordelijkTeamId,
            int medewerkerId, List<int> planbaarDoorTeamIds, int boekjaar, int budget)
        {
            Id = id;
            Naam = naam;
            Startdatum = startDatum;
            Einddatum = eindDatum;
            VerantwoordelijkTeamId = verantwoordelijkTeamId;
            MedewerkerId = medewerkerId;
            PlanbaarDoorTeamIds = planbaarDoorTeamIds;
            Boekjaar = boekjaar;
            Budget = budget;
        }
    }
}