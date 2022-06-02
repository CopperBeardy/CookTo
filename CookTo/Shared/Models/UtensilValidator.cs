namespace CookTo.Shared.Models;
public class UtensilValidator : AbstractValidator<Utensil>
{
    public UtensilValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("you must choose or enter a value");
    }
}
