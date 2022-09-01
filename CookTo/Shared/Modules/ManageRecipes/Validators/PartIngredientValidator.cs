namespace CookTo.Shared.Modules.ManageRecipes.Validators;

public class PartIngredientValidator : AbstractValidator<PartIngredient>
{
    public PartIngredientValidator() { RuleFor(x => x.Ingredient).NotNull().WithMessage("Please enter  a Ingredient"); }
}
