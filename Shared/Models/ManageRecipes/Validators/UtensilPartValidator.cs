using FluentValidation;

namespace CookTo.Shared.Models.ManageRecipes.Validators;

public class UtensilPartValidator : AbstractValidator<UtensilPart>
{
    public UtensilPartValidator()
    {
        RuleFor(x => x.Utensil).NotEmpty().WithMessage("Please select a Utensil");


        RuleFor(x => x.RequiredAmount).NotEmpty().WithMessage("Please select the number required");
        RuleFor(x => x.RequiredAmount).GreaterThan(0).WithMessage("Please provide a number equal to or greater than 1");
    }
}
