using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Commands;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Responses;

namespace QPlanning.Business.UseCases.Klanten.Get
{
    public class GetKlantDorpDownUseCase : IRequestHandler<GetKlantDownDownCommand, GetKlantDropDownResponse>
    {
        private readonly IQPlanningDomainService _qPlanningDomainService;

        public GetKlantDorpDownUseCase(IQPlanningDomainService qPlanningDomainService)
        {
            _qPlanningDomainService = qPlanningDomainService;
        }
        public Task<GetKlantDropDownResponse> Handle(GetKlantDownDownCommand request, CancellationToken cancellationToken)
        {
            var dropDownValues = _qPlanningDomainService.GetKlantDropDownValues(request.Email);
            return dropDownValues;
        }
    }
}