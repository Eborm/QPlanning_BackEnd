using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.UseCases.Boeking.Get
{
    public class GetBookingDetailUseCase: IRequestHandler<GetBookingDetailCommand, BookingDetailResponse>

    {
        private readonly IBoekingService _boekingService;

        public GetBookingDetailUseCase(IBoekingService boekingService)
        {
            _boekingService = boekingService;
        }
        
        public async Task<BookingDetailResponse> Handle(GetBookingDetailCommand request, CancellationToken cancellationToken)
        {
            return await _boekingService.GetDetailBoekingenWithingPeriod(request.StartDate, request.EndDate, request.Email, request.TeamId);
        }
    }
}