using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Dto.Commands
{
	public class CreateUserCommand : IRequest<BaseResponse>
	{
		public CreateUserCommand(string voornaam, string achternaam, string email, string userName ,string password)
		{
			Voornaam = voornaam;
			Achternaam = achternaam;
			Email = email;
			UserName = userName;
			Password = password;
		}


		public string Voornaam { get; set; }
		public string Achternaam { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
