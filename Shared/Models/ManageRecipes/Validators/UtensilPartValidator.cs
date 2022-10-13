using FluentValidation;

namespace CookTo.Shared.Models.ManageRecipes.Validators;

public sealed  class UtensilPartValidator : AbstractValidator<UtensilPart>
{
    public UtensilPartValidator() { RuleFor(x => x.Utensil).NotEmpty().WithMessage("Please select a Utensil"); }
}
