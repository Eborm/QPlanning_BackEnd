using FluentValidation;
using QPlanning.Business.UseCases.Authentication.Login.Dto.Command;

namespace QPlanning.Business.UseCases.Authentication.Login.Validator
{
	public class LoginCommandValidator : AbstractValidator<LoginCommand>
	{
		public LoginCommandValidator()
		{
			RuleFor(x => x.Email).NotEmpty();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}
