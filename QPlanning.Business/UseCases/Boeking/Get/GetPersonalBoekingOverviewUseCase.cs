using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.UseCases.Boeking.Get
{
    public class GetPersonalBoekingOverviewUseCase : IRequestHandler<GetPersonalBoekingenCommand, BoekingPeriodResponse>
    {
        private readonly IBoekingService _boekingService;

        public GetPersonalBoekingOverviewUseCase(IBoekingService boekingService)
        {
            _boekingService = boekingService;
        }
        
        public async Task<BoekingPeriodResponse> Handle(GetPersonalBoekingenCommand request, CancellationToken cancellationToken)
        {
           var result =  await _boekingService.GetPersonalBoekingenWithinPeriod(request.StartDate, request.EndDate, request.Email);
           return result;
        }
    }
}