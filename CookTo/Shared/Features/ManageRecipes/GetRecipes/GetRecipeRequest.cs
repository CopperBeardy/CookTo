using CookTo.Shared.Features.ManageRecipes.Shared;
using MediatR;

namespace CookTo.Shared.Features.ManageRecipes.GetRecipes;

public record GetRecipeRequest(string recipeId) : IRequest<GetRecipeRequest.Response>
{
    public const string RouteTemplate = "/api/recipe/{recipeId}";

    public record Response(RecipeDto recipe);
}
