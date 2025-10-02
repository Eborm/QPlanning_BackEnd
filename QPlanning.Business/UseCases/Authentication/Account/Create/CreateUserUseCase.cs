using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using MediatR;
using System.Threading;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.UseCases.Authentication.Account.Create
{
	public class CreateUserUseCase : IRequestHandler<CreateUserCommand, BaseResponse>
	{
		private readonly IAuthenticationService _iAuthenticationService;

		public CreateUserUseCase(IAuthenticationService iAuthenticationService)
		{
			_iAuthenticationService = iAuthenticationService;
		}
		
		public async Task<BaseResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var newUser = new DomainModelUser
			{
				Voornaam = request.Voornaam, 
				Achternaam = request.Achternaam, 
				Email = request.Email,
				UserName = request.UserName
			};
			var response = await _iAuthenticationService.CreateUser(newUser, request.Password);			
			return response;
		}
	}
}
