using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Boeking.Delete.Dto;
using QPlanning.Business.UseCases.Boeking.Dto;

namespace QPlanning.Business.UseCases.Boeking.Delete
{
    public class DeleteBoekingUseCase : IRequestHandler<DeleteBoekingCommand, BoekingResponse>
    {
        private readonly IBoekingService _boekingService;

        public DeleteBoekingUseCase(IBoekingService boekingService)
        {
            _boekingService = boekingService;
        }
        
        public Task<BoekingResponse> Handle(DeleteBoekingCommand request, CancellationToken cancellationToken)
        {
            return _boekingService.DeleteBoeking(request.Id);
        }
    }
}