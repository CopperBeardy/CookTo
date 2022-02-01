using CookTo.Shared.Features.ManageRecipes.AddRecipe;

namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class AddRecipeRequestValidator : AbstractValidator<AddRecipeRequest>
{
    public AddRecipeRequestValidator() { RuleFor(x => x.recipe).SetValidator(new RecipeDtoValidator()); }
}