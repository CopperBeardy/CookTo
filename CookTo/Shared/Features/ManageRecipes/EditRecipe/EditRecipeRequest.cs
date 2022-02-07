using CookTo.Shared.Features.ManageRecipes.Shared;
using MediatR;

namespace CookTo.Shared.Features.ManageRecipes.EditRecipe;

public record EditRecipeRequest(RecipeDto recipe) : IRequest<EditRecipeRequest.Response>
{
    public const string RouteTemplate = "api/recipe";
    public record Response(bool IsSuccess);
}
