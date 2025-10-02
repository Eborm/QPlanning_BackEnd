using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Authorization.Claims.Roles.Create.Dto.Command;

namespace QPlanning.Business.UseCases.Authorization.Claims.Roles.Create
{
	public class CreateRoleUseCase : IRequestHandler<CreateRoleCommand, BaseResponse>
	{
		private readonly IAuthorizationService _iqPlanningAuthorizationService;
		public CreateRoleUseCase(IAuthorizationService iqPlanningAuthorizationService)
		{
			_iqPlanningAuthorizationService = iqPlanningAuthorizationService;
		}
		public async Task<BaseResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
		{
			var response = await _iqPlanningAuthorizationService.CreateClaimRole(request.Email, request.Role);
			return response;
		}
	}
}
