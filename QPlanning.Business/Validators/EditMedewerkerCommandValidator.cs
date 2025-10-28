using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using QPlanning.Business.UseCases.Medewerkers.Add.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Edit.Dto.Command;

namespace QPlanning.Business.Validators;

public class EditMedewerkerCommandValidator : AbstractValidator<EditMedewerkerCommand>
{
    public EditMedewerkerCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id cannot be null.")
            .NotEmpty().WithMessage("Id cannot be empty.");
        
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

        RuleFor(x => x.TussenVoegsel)
            .MaximumLength(50).WithMessage("Tussenvoegsel cannot be longer than 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .NotNull().WithMessage("Email cannot be null.")
            .MinimumLength(5).WithMessage("Email address cannot be shorter than 5 characters.")
            .MaximumLength(254).WithMessage("Email address cannot be longer than 254 characters.")
            .EmailAddress().WithMessage("Email address is invalid.");

        RuleFor(x => x.Tarief)
            .NotEmpty().WithMessage("Tarief cannot be empty.")
            .NotNull().WithMessage("Tarief cannot be null.")
            .GreaterThan(0).WithMessage("Tarief must be greater than 0.");

        RuleFor(x => x.InternTarief)
            .NotEmpty().WithMessage("InternTarief cannot be empty.")
            .NotNull().WithMessage("InternTarief cannot be null.")
            .GreaterThan(0).WithMessage("InternTarief must be greater than 0.");
    }
}