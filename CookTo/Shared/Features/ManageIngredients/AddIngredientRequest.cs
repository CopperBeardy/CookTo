using MediatR;

namespace CookTo.Shared.Features.ManageIngredients;

public record AddIngredientRequest(IngredientResultDto ingredient) : IRequest<AddIngredientRequest.Response>
{
    public const string RouteTemplate = "api/Ingredient";
    public record Response(IngredientResultDto ingredient);
}
