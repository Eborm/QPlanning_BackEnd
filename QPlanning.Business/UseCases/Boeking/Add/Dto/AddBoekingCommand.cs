using System;
using System.Collections.Generic;
using MediatR;
using QPlanning.Business.UseCases.Boeking.Dto;

namespace QPlanning.Business.UseCases.Boeking.Add.Dto
{
    public class AddBoekingCommand : IRequest<BoekingResponse>
    {
        public int? Id { get; set; }
        public int? Jaar { get; set; }
        public int? Boekjaar { get; set; }
        public int? Weeknummer { get; set; }
        public int Uren { get; set; }

        public DateTime PlannedDate { get; set; }
        public int? MedewerkerId { get; set; }
        
        public List<int> MedewerkerIds { get; set; }
        public int? KlantId { get; set; }
        public int? OpdrachtId { get; set; }
        public int? IndirecteUrenId { get; set; }

        public AddBoekingCommand(
                int? id, int? jaar, int? boekjaar, int? weeknummer, int uren, DateTime plannedDate,
                int? medewerkerId, int? klantId, int? opdrachtId, int? indirecteUrenId)
        {
            Id = id;
            Jaar = jaar;
            Boekjaar = boekjaar;
            Weeknummer = weeknummer;
            Uren = uren;
            PlannedDate = plannedDate;
            MedewerkerId = medewerkerId;
            KlantId = klantId;
            OpdrachtId = opdrachtId;
            IndirecteUrenId = indirecteUrenId;
        }
    }
}