using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Interfaces.Base;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Medewerkers.Edit.Dto.Command;

namespace QPlanning.Business.UseCases.Medewerkers.Edit
{
    public class EditMedewerkerUseCase : IRequestHandler<EditMedewerkerCommand,  UseCaseResponseMessage>
    {
        private readonly IMedewerkerService _medewerkerService;

        public EditMedewerkerUseCase(IMedewerkerService medewerkerService)
        {
            _medewerkerService = medewerkerService;
        }
        
        public async Task<UseCaseResponseMessage> Handle(EditMedewerkerCommand request, CancellationToken cancellationToken)
        { 
            var result = await _medewerkerService.EditMewerker(request);
            return result;
        }
    }
}