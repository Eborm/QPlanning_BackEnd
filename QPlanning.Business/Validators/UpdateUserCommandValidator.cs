using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.UseCases.Authentication.Account.Update.Dto.Command;

namespace QPlanning.Business.Validators;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Voornaam)
            .NotEmpty().WithMessage("Voornaam cannot be empty.")
            .NotNull().WithMessage("Voornaam cannot be null.")
            .MinimumLength(2).WithMessage("Voornaam cannot be shorter than 2 characters.")
            .MaximumLength(100).WithMessage("Voornaam cannot be longer than 100 characters.");
        
        RuleFor(x => x.Achternaam)
            .NotEmpty().WithMessage("Achternaam cannot be empty.")
            .NotNull().WithMessage("Achternaam cannot be null.")
            .MinimumLength(2).WithMessage("Achternaam cannot be shorter than 2 characters.")
            .MaximumLength(100).WithMessage("Achternaam cannot be longer than 100 characters.");
        
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username cannot be empty.")
            .NotNull().WithMessage("Username cannot be null.")
            .MinimumLength(2).WithMessage("Username cannot be shorter than 2 characters.")
            .MaximumLength(100).WithMessage("Username cannot be longer than 100 characters.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .NotNull().WithMessage("Email cannot be null.")
            .MinimumLength(5).WithMessage("Email address cannot be shorter than 5 characters.")
            .MaximumLength(254).WithMessage("Email address cannot be longer than 254 characters.")
            .EmailAddress().WithMessage("Email address is invalid.");
    }
}