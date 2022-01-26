using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.RecipeDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Server.Features.ManageRecipes;

public class AddRecipeEndpoint : EndpointBaseAsync.WithRequest<AddRecipeRequest>.WithActionResult<RecipeResultDto>
{
    readonly IMapper _mapper;
    readonly IRecipeService _recipeService;

    public AddRecipeEndpoint(IRecipeService RecipeService, IMapper mapper)
    {
        _recipeService = RecipeService;
        _mapper = mapper;
    }

    [HttpPost(AddRecipeRequest.RouteTemplate)]
    public override async Task<ActionResult<RecipeResultDto>> HandleAsync(
        AddRecipeRequest request,
        CancellationToken cancellationToken = default)
    {
        Recipe recipe = _mapper.Map<Recipe>(request.recipe);
        await _recipeService.CreateAsync(recipe);
        return Ok(_mapper.Map<RecipeResultDto>(recipe));
    }
}
