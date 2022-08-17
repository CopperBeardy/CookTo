using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Shared.Modules.ManageCuisines;

public class CuisineValidator : AbstractValidator<Utensil>
{
    public CuisineValidator() { RuleFor(x => x.Name).NotEmpty().WithMessage("you must choose or enter a value"); }
}
