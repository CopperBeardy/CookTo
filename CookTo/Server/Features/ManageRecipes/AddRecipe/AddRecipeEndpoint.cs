using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.RecipeDocument;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes.AddRecipe;
using CookTo.Shared.Features.ManageRecipes.Shared;


namespace CookTo.Server.Features.ManageRecipes.AddRecipe;

public class AddRecipeEndpoint : EndpointBaseAsync.WithRequest<AddRecipeRequest>.WithActionResult<RecipeDto>
{
    readonly IRecipeService _recipeService;
    readonly IMapper _mapper;

    public AddRecipeEndpoint(IRecipeService RecipeService, IMapper mapper)
    {
        _recipeService = RecipeService;
        _mapper = mapper;
    }

    [HttpPost(AddRecipeRequest.RouteTemplate)]
    public override async Task<ActionResult<RecipeDto>> HandleAsync(
        AddRecipeRequest request,
        CancellationToken cancellationToken = default)
    {
        var recipe = _mapper.Map<Recipe>(request.recipe);
        await _recipeService.CreateAsync(recipe, cancellationToken);
        return Ok(_mapper.Map<RecipeDto>(recipe));
    }
}