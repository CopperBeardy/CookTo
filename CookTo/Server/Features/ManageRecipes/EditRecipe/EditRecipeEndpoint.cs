using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.RecipeDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes.EditRecipe;

namespace CookTo.Server.Features.ManageRecipes.EditRecipe;

public class EditRecipeEndpoint : EndpointBaseAsync.WithRequest<EditRecipeRequest>.WithActionResult<bool>
{
    readonly IRecipeService _recipeService;
    readonly IMapper _mapper;

    public EditRecipeEndpoint(IRecipeService RecipeService, IMapper mapper)
    {
        _recipeService = RecipeService;
        _mapper = mapper;
    }

    [HttpPut(EditRecipeRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(
        EditRecipeRequest request,
        CancellationToken cancellationToken = default)
    {
        var recipe = _mapper.Map<Recipe>(request.recipe);
        if(request.recipe.ImageAction == ImageAction.Remove)
        {
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", recipe.Image!));
            recipe.Image = null;
        }
        await _recipeService.UpdateAsync(recipe, cancellationToken);
        return Ok(true);
    }
}