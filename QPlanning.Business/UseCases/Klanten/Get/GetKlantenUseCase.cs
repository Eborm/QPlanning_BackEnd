using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Commands;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Responses;

namespace QPlanning.Business.UseCases.Klanten.Get
{
    public class GetKlantenUseCase : IRequestHandler<GetKlantenCommand, GetKlantenResponse>
    {
        private readonly IQPlanningDomainService _qPlanningDomainService;

        public GetKlantenUseCase(IQPlanningDomainService qPlanningDomainService)
        {
            _qPlanningDomainService = qPlanningDomainService;
        }
        
        public async Task<GetKlantenResponse> Handle(GetKlantenCommand request, CancellationToken cancellationToken)
        {
            var klanten = await _qPlanningDomainService.GetKlantenForTeam(request.Email);
            return klanten;
        }
    }
}