using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Response;

namespace QPlanning.Business.UseCases.Medewerkers.Get
{
    public class GetMedewerkersUseCase : IRequestHandler<GetMedewerkersCommand, GetMedewerkersResponse>
    {
        private readonly IMedewerkerService _medewerkerService;

        public GetMedewerkersUseCase(IMedewerkerService medewerkerService)
        {
            _medewerkerService = medewerkerService;
        }
        
        public async Task<GetMedewerkersResponse> Handle(GetMedewerkersCommand request, CancellationToken cancellationToken)
        {
            var result = await _medewerkerService.GetMedewerkers();
            var getMedewerkersRepsonse = new GetMedewerkersResponse
            {
                Medewerkers = result
            };
            return getMedewerkersRepsonse;
        }
    }
}