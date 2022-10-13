using CookTo.Shared.Models.ManageUtensils;
using FluentValidation;

namespace CookTo.Shared.Models.ManageCuisines;

public sealed class CuisineValidator : AbstractValidator<Utensil>
{
    public CuisineValidator() { RuleFor(x => x.Name).NotEmpty().WithMessage("you must choose or enter a value"); }
}
