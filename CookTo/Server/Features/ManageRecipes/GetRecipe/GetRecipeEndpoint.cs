using Ardalis.ApiEndpoints;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes.GetRecipes;
using CookTo.Shared.Features.ManageRecipes.Shared;

namespace CookTo.Server.Features.ManageRecipes.GetRecipe;

public class GetRecipeEndpoint : EndpointBaseAsync.WithRequest<string>.WithActionResult<GetRecipeRequest.Response>
{
    private readonly IRecipeService _recipeService;


    public GetRecipeEndpoint(IRecipeService recipeService) { _recipeService = recipeService; }

    [HttpGet(GetRecipeRequest.RouteTemplate)]
    public override async Task<ActionResult<GetRecipeRequest.Response>> HandleAsync(
        string recipeId,
        CancellationToken cancellationToken = default)
    {
        var recipe = await _recipeService.GetByIdAsync(recipeId, cancellationToken);

        if(recipe is null)
        {
            return BadRequest("Recipe could not be found.");
        }

        return Ok(RecipeMapping.FromRecipeToDto(recipe));
    }
}
