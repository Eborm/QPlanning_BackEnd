using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Response;

namespace QPlanning.Business.UseCases.Medewerkers.Get
{
    public class GetMedewerkerDropDownUseCase : IRequestHandler<GetMedewerkerDropDownCommand, MedewerkerDropDownResponse>
    {
        private readonly IQPlanningDomainService _qPlanningDomainService;

        public GetMedewerkerDropDownUseCase(IQPlanningDomainService qPlanningDomainService)
        {
            _qPlanningDomainService = qPlanningDomainService;
        }
        
        public async Task<MedewerkerDropDownResponse> Handle(GetMedewerkerDropDownCommand request, CancellationToken cancellationToken)
        {
           var result = await _qPlanningDomainService.GetMedewerkerDropDownValues();
           return result;
        }
    }
}