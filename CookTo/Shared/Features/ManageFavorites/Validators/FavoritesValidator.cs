
namespace CookTo.Shared.Features.ManageFavorites.Validators;

public class FavoritesValidator : AbstractValidator<FavoritesDto>
{
    public FavoritesValidator() { RuleFor(x => x.Username).NotEmpty().WithMessage("username of the current user is needed"); }
}