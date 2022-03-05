using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Shared.Features.ManageCategory.Validators;

public class CategoryDtoValidator : AbstractValidator<IngredientDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please provide the category name");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Please provide a category longer than 2 characters");
    }
}