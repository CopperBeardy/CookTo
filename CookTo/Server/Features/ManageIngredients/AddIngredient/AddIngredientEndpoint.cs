using Ardalis.ApiEndpoints;
using CookTo.Server.Documents.IngredientDocument;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageIngredients.AddIngredient;
using CookTo.Shared.Features.ManageIngredients.Shared;

namespace CookTo.Server.Features.ManageIngredients.AddIngredient;

public class AddIngredientEndpoint : EndpointBaseAsync.WithRequest<AddIngredientRequest>.WithActionResult<IngredientDto>
{
    readonly IIngredientService _ingredientService;

    public AddIngredientEndpoint(IIngredientService ingredientService) { _ingredientService = ingredientService; }

    [HttpPost(AddIngredientRequest.RouteTemplate)]
    public override async Task<ActionResult<IngredientDto>> HandleAsync(
        AddIngredientRequest request,
        CancellationToken cancellationToken = default)
    {
        Ingredient ingredient = IngredientMapping.FromDtoToIngredient(request.ingredient);
        await _ingredientService.CreateAsync(ingredient, cancellationToken);
        return Ok(IngredientMapping.FromIngredientToDto(ingredient));
    }
}
