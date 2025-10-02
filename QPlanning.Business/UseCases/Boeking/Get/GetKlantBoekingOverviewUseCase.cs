using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.UseCases.Boeking.Get
{
    public class GetKlantBoekingOverviewUseCase : IRequestHandler<GetKlantBoekingenCommand, BoekingPeriodResponse>
    {
        private readonly IBoekingService _boekingService;

        public GetKlantBoekingOverviewUseCase(IBoekingService boekingService)
        {
            _boekingService = boekingService;
        }

        public async Task<BoekingPeriodResponse> Handle(GetKlantBoekingenCommand request,
            CancellationToken cancellationToken)
        {
            var result =
                await _boekingService.GetKlantBoekingenWithinPeriod(request.StartDate, request.EndDate, request.Email, request.TeamId, request.KlantIds);
            return result;
        }
    }
}