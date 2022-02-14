﻿
namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class UtensilPartValidator : AbstractValidator<UtensilPart>
{
    public UtensilPartValidator()
    {
        RuleFor(x => x.UtensilName).NotEmpty().WithMessage("Please select a Utensil");
        RuleFor(x => x.UtensilName).NotEqual("Select Utensil...").WithMessage("Please select a Utensil");

        RuleFor(x => x.RequiredAmount).NotEmpty().WithMessage("Please select the number required");
        RuleFor(x => x.RequiredAmount).GreaterThan(0).WithMessage("Please provide a number equal to or greater than 1");
    }
}
