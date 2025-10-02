using System;
using System.Collections.Generic;
using MediatR;
using QPlanning.Business.Dto.Response.UseCase;

namespace QPlanning.Business.Dto.Commands
{
    public class GetKlantBoekingenCommand : IRequest<BoekingPeriodResponse>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Email { get; set; }
        
        public int? TeamId { get; set; }

        public List<int> KlantIds { get; set; }
    }

}