using CookTo.Shared.Features.ManageIngredients.Shared;

namespace CookTo.Shared.Features.ManageIngredients.Validators;

public class IngredientDtoValidator : AbstractValidator<IngredientDto>
{
    public IngredientDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please provide the name of this ingredient");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Please provide a name longer than 2 characters");
        RuleFor(x => x.Name).NotEqual("Select item ...").WithMessage("Please select a item");
    }
}