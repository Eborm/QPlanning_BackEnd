using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Interfaces.Base;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Medewerkers.Toggle.Dto.Command;

namespace QPlanning.Business.UseCases.Medewerkers.Toggle
{
    public class ToggleMedewerkerUseCase : IRequestHandler<DeleteMedewerkerCommand, UseCaseResponseMessage>
    {
        private readonly IMedewerkerService _medewerkerService;

        public ToggleMedewerkerUseCase(IMedewerkerService medewerkerService)
        {
            _medewerkerService = medewerkerService;
        }
        
        public async Task<UseCaseResponseMessage> Handle(DeleteMedewerkerCommand request, CancellationToken cancellationToken)
        {
            var result = await _medewerkerService.ToggleActiveMedwerker(request.Id, request.IsActief);
            return result;
        }
    }
}