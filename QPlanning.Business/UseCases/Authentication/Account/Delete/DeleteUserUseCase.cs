using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.UseCases.Authentication.Account.Delete
{
    public class DeleteUserUseCase : IRequestHandler<DeleteUserCommand, BaseResponse>
    {
        private readonly IAuthenticationService _iAuthenticationService;

        public DeleteUserUseCase(IAuthenticationService iAuthenticationService)
        {
            _iAuthenticationService = iAuthenticationService;
        }
        public async Task<BaseResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _iAuthenticationService.DeleteUser(request.Email);			
            return response;
        }
    }
}