using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using QPlanning.Business.UseCases.Klanten.Add.Dto.Commands;

namespace QPlanning.Business.Validators;

public class AddKlantCommandValidator : AbstractValidator<AddKlantCommand>
{
    public AddKlantCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id cannot be null.");
        
        RuleFor(x => x.VerantwoordelijkTeamId)
            .NotNull().WithMessage("VerantwoordelijkTeamId cannot be null.");

        RuleFor(x => x.MedewerkerId)
            .NotNull().WithMessage("MedewerkerId cannot be null.");

        RuleFor(x => x.PlanbaarDoorTeamIds)
            .NotEmpty().WithMessage("PlanbaarDoorTeamsIds cannot be empty.")
            .NotNull().WithMessage("PlanbaarDoorTeamsIds cannot be null.");
        
        RuleFor(x => x.Naam)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .NotNull().WithMessage("Name cannot be null.")
            .MinimumLength(2).WithMessage("Name cannot be shorter than 2 characters.")
            .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

        RuleFor(x => x.Startdatum)
            .NotNull().WithMessage("Startdatum cannot be null.");
        
        RuleFor(x => x.Einddatum)
            .NotNull().WithMessage("Einddatum cannot be null.")
            .GreaterThan(x => x.Startdatum).WithMessage("Einddatum must be after Startdatum.");
        
        RuleFor(x => x.Boekjaar)
            .NotNull().WithMessage("Boekjaar cannot be null.")
            .GreaterThanOrEqualTo(DateTime.Today.Year).WithMessage("Boekjaar cannot be in the past.");
        
        RuleFor(x => x.Budget)
            .NotNull().WithMessage("Budget cannot be null.")
            .GreaterThan(0).WithMessage("Budget must be greater than 0.");
    }
}