using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageIngredients.GetIngredients;
using CookTo.Shared.Features.ManageIngredients.Shared;

namespace CookTo.Server.Features.ManageIngredients.GetIngredient;

public class GetIngredientsEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetIngredientsRequest.Response>
{
    private readonly IIngredientService _Ingredientservice;
    readonly IMapper _mapper;

    public GetIngredientsEndpoint(IIngredientService Ingredientservice, IMapper mapper)
    {
        _Ingredientservice = Ingredientservice;
        _mapper = mapper;
    }


    [HttpGet(GetIngredientsRequest.RouteTemplate)]
    public override async Task<ActionResult<GetIngredientsRequest.Response>> HandleAsync(
        int ingredientId,
        CancellationToken cancellationToken = default)
    {
        var ingredients = await _Ingredientservice.GetAllAsync(cancellationToken);
        var response = new GetIngredientsRequest.Response(
            ingredients.Select(ingredient => new IngredientDto() { Id = ingredient.Id, Name = ingredient.Name }));


        return Ok(response);
    }
}
