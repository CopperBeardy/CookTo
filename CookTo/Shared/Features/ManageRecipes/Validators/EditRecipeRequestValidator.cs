using CookTo.Shared.Features.ManageRecipes.EditRecipe;

namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class EditRecipeRequestValidator : AbstractValidator<EditRecipeRequest>
{
    public EditRecipeRequestValidator() { RuleFor(x => x.recipe).SetValidator(new RecipeDtoValidator()); }
}