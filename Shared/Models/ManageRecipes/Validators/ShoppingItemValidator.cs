using FluentValidation;

namespace CookTo.Shared.Models.ManageRecipes.Validators;

public sealed   class ShoppingItemValidator : AbstractValidator<ShoppingItem>
{
    public ShoppingItemValidator() { RuleFor(x => x.Ingredient).NotNull().WithMessage("Please enter  a Ingredient"); }
}
