using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.UseCases.Boeking.Get
{
    public class GetMedewerkerBoekingenUseCase: IRequestHandler<GetMedewerkerBoekingenCommand, BoekingPeriodResponse>
    {
        private readonly IBoekingService _boekingService;

        public GetMedewerkerBoekingenUseCase(IBoekingService boekingService)
        {
            _boekingService = boekingService;
        }

        public async Task<BoekingPeriodResponse> Handle(GetMedewerkerBoekingenCommand request, CancellationToken cancellationToken)
        {
            var result =
                await _boekingService.GetMedewerkerBoekingenWithinPeriod(request.StartDate, request.EndDate, request.Email, request.TeamId, request.MedewerkerIds);
            return result;
        }
    }
}