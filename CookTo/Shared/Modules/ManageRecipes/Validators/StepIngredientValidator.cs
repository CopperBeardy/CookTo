namespace CookTo.Shared.Modules.ManageRecipes.Validators;

public class StepIngredientValidator : AbstractValidator<StepIngredient>
{
    public StepIngredientValidator()
    {
        RuleFor(x => x.Ingredient).NotEmpty().WithMessage("Please select a Ingredient");
        RuleFor(x => x.Ingredient).NotEqual("select ingredient");
    }
}