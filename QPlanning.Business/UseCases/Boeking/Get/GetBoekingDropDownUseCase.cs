using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.UseCases.Boeking.Get.Dto;

namespace QPlanning.Business.UseCases.Boeking.Get
{
    public class GetBoekingDropDownUseCase : IRequestHandler<GetBoekingDropDownCommand, BoekingDropDownResponse>
    {
        private readonly IQPlanningDomainService _qPlanningDomainService;

        public GetBoekingDropDownUseCase(IQPlanningDomainService qPlanningDomainService)
        {
            _qPlanningDomainService = qPlanningDomainService;
        }
        public async Task<BoekingDropDownResponse> Handle(GetBoekingDropDownCommand request, CancellationToken cancellationToken)
        {
            return await _qPlanningDomainService.GetBoekingDropDownValues(request.Email);
        }
    }
}