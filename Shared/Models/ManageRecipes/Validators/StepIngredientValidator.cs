using FluentValidation;

namespace CookTo.Shared.Models.ManageRecipes.Validators;

public class StepIngredientValidator : AbstractValidator<CookingStepIngredient>
{
    public StepIngredientValidator()
    { RuleFor(x => x.Ingredient).NotEmpty().WithMessage("Please select a Ingredient"); }
}