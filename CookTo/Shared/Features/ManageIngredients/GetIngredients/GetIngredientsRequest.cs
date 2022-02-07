using CookTo.Shared.Features.ManageIngredients.Shared;
using MediatR;


namespace CookTo.Shared.Features.ManageIngredients.GetIngredients;

public record GetIngredientsRequest : IRequest<GetIngredientsRequest.Response>
{
    public const string RouteTemplate = "/api/ingredient";

    public record Response(IEnumerable<IngredientDto> Ingredients);
}
