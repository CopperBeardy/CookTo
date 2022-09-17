using FluentValidation;

namespace CookTo.Shared.Models.ManageCategories;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator() { RuleFor(x => x.Name).NotEmpty().WithMessage("you must choose or enter a value"); }
}
