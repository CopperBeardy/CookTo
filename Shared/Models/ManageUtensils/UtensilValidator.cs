using FluentValidation;

namespace CookTo.Shared.Models.ManageUtensils;

public class UtensilValidator : AbstractValidator<Utensil>
{
    public UtensilValidator() { RuleFor(x => x.Name).NotEmpty().WithMessage("you must choose or enter a value"); }
}
