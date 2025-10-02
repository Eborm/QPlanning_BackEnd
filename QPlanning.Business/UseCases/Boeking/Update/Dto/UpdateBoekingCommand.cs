using System;
using MediatR;
using QPlanning.Business.UseCases.Boeking.Dto;

namespace QPlanning.Business.UseCases.Boeking.Update.Dto
{
    public class UpdateBoekingCommand : IRequest<BoekingResponse>
    {
        public int? Id { get; set; }
        public int? Jaar { get; set; }

        public int? Boekjaar { get; set; }
        public int? Weeknummer { get; set; }

        public DateTime PlannedDate { get; set; }
        public int Uren { get; set; }
        public int MedewerkerId { get; set; }
        public int? KlantId { get; set; }
        public int? OpdrachtId { get; set; }
        public int? IndirecteUrenId { get; set; }
    }
}