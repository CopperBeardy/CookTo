using MediatR;

namespace CookTo.Shared.Features.ManageIngredients;

public record AddIngredientRequest(IngredientDto ingredient) : IRequest<AddIngredientRequest.Response>
{
    public const string RouteTemplate = "api/Ingredient";
    public record Response(IngredientDto ingredient);
}
