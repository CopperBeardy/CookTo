using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace CookTo.Shared.Features.ManageRecipes.Shared;

public record UploadRecipeImageRequest(string RecipeId, IBrowserFile File) : IRequest<UploadRecipeImageRequest.Response>
{
    public const string RouteTemplate = "/api/recipes/{recipeId}/images";
    public record Response(string ImageName);
}
