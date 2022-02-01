using CookTo.Shared.Features.ManageRecipes.Shared;
using MediatR;

namespace CookTo.Shared.Features.ManageRecipes.AddRecipe;

public record AddRecipeRequest(RecipeDto recipe) : IRequest<AddRecipeRequest.Response>
{
    public const string RouteTemplate = "/api/Recipe";
    public record Response(RecipeDto recipe);
}
