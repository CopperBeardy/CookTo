using CookTo.Shared.Features.ManageIngredients.Shared;
using MediatR;

namespace CookTo.Shared.Features.ManageIngredients.AddIngredient;

public record AddIngredientRequest(IngredientDto ingredient) : IRequest<AddIngredientRequest.Response>
{
    public const string RouteTemplate = "api/ingredient";
    public record Response(IngredientDto ingredient);
}
