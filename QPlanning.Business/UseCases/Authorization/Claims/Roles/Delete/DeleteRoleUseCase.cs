using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Authorization.Claims.Roles.Delete.Dto.Command;

namespace QPlanning.Business.UseCases.Authorization.Claims.Roles.Delete
{
    public class DeleteRoleUseCase : IRequestHandler<DeleteRoleCommand, BaseResponse>
    {
        private readonly IAuthorizationService _authorizationService;

        public DeleteRoleUseCase(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        
        public async Task<BaseResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
           return await _authorizationService.DeleteClaimRole(request.Email, request.Role);
        }
    }
}