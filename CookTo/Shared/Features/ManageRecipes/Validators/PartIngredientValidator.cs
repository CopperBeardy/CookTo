namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class PartIngredientValidator : AbstractValidator<PartIngredient>
{
    public PartIngredientValidator()
    { RuleFor(x => x.Ingredient).NotEmpty().WithMessage("Please select a Ingredient"); }
}