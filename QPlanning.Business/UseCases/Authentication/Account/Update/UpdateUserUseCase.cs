using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Authentication.Account.Update.Dto.Command;

namespace QPlanning.Business.UseCases.Authentication.Account.Update
{
    public class UpdateUserUseCase : IRequestHandler<UpdateUserCommand, BaseResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public UpdateUserUseCase(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<BaseResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var domainModelUser = new DomainModelUser
            {
                Id = request.Id,
                Voornaam = request.Voornaam,
                Achternaam = request.Achternaam,
                Email = request.Email,
                UserName = request.Email
            };
           var result = await _authenticationService.UpdateUser(domainModelUser);
           return result;
        }
    }
}