using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Interfaces.Base;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Medewerkers.Add.Dto.Command;

namespace QPlanning.Business.UseCases.Medewerkers.Add
{
    public class AddMedwerkerUseCase : IRequestHandler<AddMedewerkerCommand, UseCaseResponseMessage>
    {
        private readonly IMedewerkerService _medewerkerService;

        public AddMedwerkerUseCase(IMedewerkerService medewerkerService)
        {
            _medewerkerService = medewerkerService;
        }
        
        public async Task<UseCaseResponseMessage> Handle(AddMedewerkerCommand request, CancellationToken cancellationToken)
        {
            var result = await _medewerkerService.AddMedewerker(request);
            return result;
        }
    }
}