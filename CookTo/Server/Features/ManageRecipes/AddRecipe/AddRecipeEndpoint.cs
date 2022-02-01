using Ardalis.ApiEndpoints;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes.AddRecipe;
using CookTo.Shared.Features.ManageRecipes.Shared;


namespace CookTo.Server.Features.ManageRecipes.AddRecipe;

public class AddRecipeEndpoint : EndpointBaseAsync.WithRequest<AddRecipeRequest>.WithActionResult<RecipeDto>
{
    readonly IRecipeService _recipeService;
    public AddRecipeEndpoint(IRecipeService RecipeService) => _recipeService = RecipeService;

    [HttpPost(AddRecipeRequest.RouteTemplate)]
    public override async Task<ActionResult<RecipeDto>> HandleAsync(
        AddRecipeRequest request,
        CancellationToken cancellationToken = default)
    {
        var recipe = RecipeMapping.FromDtoToRecipe(request.recipe);
        await _recipeService.CreateAsync(recipe, cancellationToken);
        return Ok(RecipeMapping.FromRecipeToDto(recipe));
    }
}