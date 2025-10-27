using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using QPlanning.Business.UseCases.Medewerkers.Add.Dto.Command;

namespace QPlanning.Business.Validators
{
    public class AddMedewerkerCommandValidator : AbstractValidator<AddMedewerkerCommand>
    {
        public AddMedewerkerCommandValidator()
        {
            RuleFor(x => x.Voornaam)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
            RuleFor(x => x.Achternaam)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
            RuleFor(x => x.TussenVoegsel)
                .MaximumLength(50);
            RuleFor(x => x.Email)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(254)
                .EmailAddress();
            RuleFor(x => x.Tarief)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
            RuleFor(x => x.InternTarief)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
