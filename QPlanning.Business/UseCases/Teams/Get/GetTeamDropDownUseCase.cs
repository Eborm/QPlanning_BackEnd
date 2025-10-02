using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Response;
using QPlanning.Business.UseCases.Teams.Get.Dto.Command;
using QPlanning.Business.UseCases.Teams.Get.Dto.Response;

namespace QPlanning.Business.UseCases.Teams.Get
{
    public class GetTeamDropDownUseCase: IRequestHandler<GetTeamDropDownCommand, TeamDropDownResponse>
    {
        private readonly IQPlanningDomainService _qPlanningDomainService;

        public GetTeamDropDownUseCase(IQPlanningDomainService qPlanningDomainService)
        {
            _qPlanningDomainService = qPlanningDomainService;
        }
        
        public async Task<TeamDropDownResponse> Handle(GetTeamDropDownCommand request, CancellationToken cancellationToken)
        {
            var result = await _qPlanningDomainService.GetTeamDropDownValues(request.Email);
            return result;
        }
    }
}