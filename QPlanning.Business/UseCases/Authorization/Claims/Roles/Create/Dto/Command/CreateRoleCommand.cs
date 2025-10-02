using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.UseCases.Authorization.Claims.Roles.Create.Dto.Command
{
	public class CreateRoleCommand : IRequest<BaseResponse>
	{
		public string Email { get; set; }
		public string Role { get; set; }
	}
}
