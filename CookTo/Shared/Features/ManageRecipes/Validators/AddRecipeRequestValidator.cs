
namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class AddRecipeRequestValidator : AbstractValidator<AddRecipeRequest>
{
    public AddRecipeRequestValidator() { RuleFor(x => x.recipe).SetValidator(new AddRecipeDtoValidator()); }
}