using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.IngredientDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Server.Features.ManageIngredients;

public class AddIngredientEndpoint : EndpointBaseAsync.WithRequest<AddIngredientRequest>.WithActionResult<IngredientResultDto>
{
    readonly IMapper _mapper;
    readonly IIngredientService _ingredientService;

    public AddIngredientEndpoint(IIngredientService ingredientService, IMapper mapper)
    {
        _ingredientService = ingredientService;
        _mapper = mapper;
    }

    [HttpPost(AddIngredientRequest.RouteTemplate)]
    public override async Task<ActionResult<IngredientResultDto>> HandleAsync(
        AddIngredientRequest request,
        CancellationToken cancellationToken = default)
    {
        Ingredient ingredient = _mapper.Map<Ingredient>(request.ingredient);
        await _ingredientService.CreateAsync(ingredient);
        return Ok(_mapper.Map<IngredientResultDto>(ingredient));
    }
}
