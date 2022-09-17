using FluentValidation;

namespace CookTo.Shared.Models.ManageRecipes.Validators;

public class ShoppingItemValidator : AbstractValidator<ShoppingItem>
{
    public ShoppingItemValidator() { RuleFor(x => x.Ingredient).NotNull().WithMessage("Please enter  a Ingredient"); }
}
