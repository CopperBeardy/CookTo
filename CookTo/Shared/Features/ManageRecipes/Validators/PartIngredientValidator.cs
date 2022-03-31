
using CookTo.Shared.Enums;

namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class PartIngredientValidator : AbstractValidator<PartIngredient>
{
    public PartIngredientValidator()
    {
        RuleFor(x => x.Unit).NotEmpty().WithMessage("Please select the appropritate measurement unit");
        RuleFor(x => x.Unit).NotEmpty().WithMessage("Please select the appropritate measurement unit");
        RuleFor(x => x.Ingredient).NotEmpty().WithMessage("Please select a Ingredient");
    }
}