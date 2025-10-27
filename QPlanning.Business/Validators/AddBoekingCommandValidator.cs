using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.UseCases.Boeking.Add.Dto;

namespace QPlanning.Business.Validators;

public class AddBoekingCommandValidator : AbstractValidator<AddBoekingCommand>
{
    public AddBoekingCommandValidator()
    {
        RuleFor(x => x.Uren)
            .GreaterThanOrEqualTo(1).WithMessage("Boeking must be at least 1 hour.")
            .LessThanOrEqualTo(24).WithMessage("Boeking cannot exceed 24 hours.");
        
        RuleFor(x => x.PlannedDate)
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Planned date cannot be in the past.");
        
        RuleFor(x => x.Boekjaar)
            .GreaterThanOrEqualTo(DateTime.Today.Year).WithMessage("Boekjaar cannot be in the past.");
        
        RuleFor(x => x.Weeknummer)
            .InclusiveBetween(1, 52).WithMessage("Weeknummer must be between 1 and 52.");
        
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.MedewerkerId)
            .GreaterThan(0).WithMessage("MedewerkerId must be greater than 0.");
        RuleFor(x => x.KlantId)
            .GreaterThan(0).WithMessage("KlantId must be greater than 0.");
        RuleFor(x => x.OpdrachtId)
            .GreaterThan(0).WithMessage("OpdrachtId must be greater than 0.");
        RuleFor(x => x.IndirecteUrenId)
            .GreaterThan(0).WithMessage("IndirecteUrenId must be greater than 0.");
        
        RuleFor(x => x.Jaar)
            .GreaterThanOrEqualTo(DateTime.Today.Year).WithMessage("Jaar cannot be in the past.");
    }
}