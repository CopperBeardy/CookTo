namespace CookTo.Shared.Models;
public class CuisineValidator : AbstractValidator<Utensil>
{
    public CuisineValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("you must choose or enter a value");
    }
}
