using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Shared.Features.ManageCuisine.Validators;

public class CuisineDtoValidator : AbstractValidator<IngredientDto>
{
    public CuisineDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please provide the type of this cuisine");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Please provide a type longer than 2 characters");
    }
}