using FluentValidation;

namespace CookTo.Shared.Models.ManageRecipes.Validators;

public class CookingStepIngredientValidator : AbstractValidator<CookingStepIngredient>
{
    public CookingStepIngredientValidator()
    { RuleFor(x => x.Ingredient).NotEmpty().WithMessage("Please select a Ingredient"); }
}