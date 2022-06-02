namespace CookTo.Shared.Models;
public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("you must choose or enter a value");
    }
}
