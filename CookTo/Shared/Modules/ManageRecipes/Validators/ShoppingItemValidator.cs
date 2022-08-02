using FluentValidation;

namespace CookTo.Shared.Modules.ManageRecipes.Validators;

public class ShoppingItemValidator : AbstractValidator<ShoppingItem>
{
    public ShoppingItemValidator() { RuleFor(x => x.Ingredient).NotNull().WithMessage("Please enter  a Ingredient"); }
}
