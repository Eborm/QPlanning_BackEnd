using MediatR;
using QPlanning.Business.UseCases.Authentication.Login.Dto.Response;

namespace QPlanning.Business.UseCases.Authentication.Login.Dto.Command
{
	public class LoginCommand : IRequest<LoginResponse>
	{
		public LoginCommand(string email, string password)
		{
			Email = email;
			Password = password;
		}

		public string Email { get; set; }
		public string Password { get; set; }

		
	}
}
