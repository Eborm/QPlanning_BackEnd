using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.UseCases.Boeking.Get
{
    public class GetBoekingExportUseCase: IRequestHandler<GetBoekingExportCommand, ExcelExportResponse>

    {
        private readonly IBoekingService _boekingService;

        public GetBoekingExportUseCase(IBoekingService boekingService)
        {
            _boekingService = boekingService;
        }
        
        public async Task<ExcelExportResponse> Handle(GetBoekingExportCommand request, CancellationToken cancellationToken)
        {
            return await _boekingService.ExportBoekingenToExcel(request.StartDate, request.EndDate, request.Email, request.TeamId);
        }
    }
}