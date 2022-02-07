using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.IngredientDocument;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageIngredients.AddIngredient;
using CookTo.Shared.Features.ManageIngredients.Shared;

namespace CookTo.Server.Features.ManageIngredients.AddIngredient;

public class AddIngredientEndpoint : EndpointBaseAsync.WithRequest<AddIngredientRequest>.WithActionResult<IngredientDto>
{
    readonly IIngredientService _ingredientService;
    readonly IMapper _mapper;
    public AddIngredientEndpoint(IIngredientService ingredientService, IMapper mapper) { _ingredientService = ingredientService;
         _mapper=mapper;
    }

    [HttpPost(AddIngredientRequest.RouteTemplate)]
    public override async Task<ActionResult<IngredientDto>> HandleAsync(
        AddIngredientRequest request,
        CancellationToken cancellationToken = default)
    {
        Ingredient ingredient = _mapper.Map<Ingredient>(request.ingredient);
        await _ingredientService.CreateAsync(ingredient, cancellationToken);
        return Ok(_mapper.Map<IngredientDto>(ingredient));
    }
}
