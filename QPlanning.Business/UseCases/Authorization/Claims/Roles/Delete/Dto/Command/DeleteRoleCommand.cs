using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.UseCases.Authorization.Claims.Roles.Delete.Dto.Response.Gateway;

namespace QPlanning.Business.UseCases.Authorization.Claims.Roles.Delete.Dto.Command
{
    public class DeleteRoleCommand : IRequest<BaseResponse>
    {
        public string Email { get; set; }
        public string Role { get; set; }
    }
}