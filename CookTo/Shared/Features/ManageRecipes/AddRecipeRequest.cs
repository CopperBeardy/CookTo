using MediatR;

namespace CookTo.Shared.Features.ManageRecipes;

public record AddRecipeRequest(RecipeDto recipe) : IRequest<AddRecipeRequest.Response>
{
    public const string RouteTemplate = "api/Recipe";
    public record Response(RecipeDto recipe);
}
