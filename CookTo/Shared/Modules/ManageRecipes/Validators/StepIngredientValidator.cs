namespace CookTo.Shared.Modules.ManageRecipes.Validators;

public class StepIngredientValidator : AbstractValidator<CookingStepIngredient>
{
    public StepIngredientValidator()
    { RuleFor(x => x.Ingredient).NotEmpty().WithMessage("Please select a Ingredient"); }
}