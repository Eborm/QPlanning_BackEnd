using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.UseCases.Authentication.Account.ResetPassword
{
    public class ResetPasswordUseCase : IRequestHandler<ResetPasswordCommand, BaseResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public ResetPasswordUseCase(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<BaseResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
           var result = await _authenticationService.ResetPassword(request.Email, request.NewPassword);
           return result;
        }
    }
}