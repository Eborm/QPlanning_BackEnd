using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.UseCases.Authentication.Account.GetAll
{
    public class GetAllUsersUseCase : IRequestHandler<GetAllUserCommand, AllUserResponse>
    {
        private readonly IAuthenticationService _iAuthenticationService;

        public GetAllUsersUseCase(IAuthenticationService iAuthenticationService)
        {
            _iAuthenticationService = iAuthenticationService;
        }
        public async Task<AllUserResponse> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            return await _iAuthenticationService.GetAllUsers();
        }
    }
}