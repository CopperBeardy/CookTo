
namespace CookTo.Shared.Features.ManageUtensils.Validators;

public class UtensilDtoValidator : AbstractValidator<UtensilDto>
{
    public UtensilDtoValidator() { RuleFor(x => x.UtensilName).NotEmpty().WithMessage("Please select a Utensil"); }
}
