using MediatR;
using System.Threading;
using System.Threading.Tasks;
using QPlanning.Business.Dto.Base;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Authentication.Login.Dto.Command;
using QPlanning.Business.UseCases.Authentication.Login.Dto.Response;

namespace QPlanning.Business.UseCases.Authentication.Login
{
    public sealed class LoginUseCase : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginUseCase(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginResponse = await _authenticationService.GenerateToken(request.Email, request.Password);
            return loginResponse;
        }
    }
}