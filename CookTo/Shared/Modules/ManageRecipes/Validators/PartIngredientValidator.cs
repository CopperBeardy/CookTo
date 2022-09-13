namespace CookTo.Shared.Modules.ManageRecipes.Validators;

public class PartIngredientValidator : AbstractValidator<RecipePartIngredient>
{
    public PartIngredientValidator() { RuleFor(x => x.Ingredient).NotNull().WithMessage("Please enter  a Ingredient"); }
}
