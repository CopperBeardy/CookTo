namespace CookTo.Shared.Modules.ManageIngredients;
public class IngredientValidator : AbstractValidator<Ingredient>
{
    public IngredientValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("you must choose or enter a value");
    }
}
