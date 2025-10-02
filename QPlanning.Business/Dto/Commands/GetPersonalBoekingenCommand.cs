using System;
using MediatR;
using QPlanning.Business.Dto.Response.UseCase;

namespace QPlanning.Business.Dto.Commands
{
    public class GetPersonalBoekingenCommand : IRequest<BoekingPeriodResponse>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Email { get; set; }
    }
}