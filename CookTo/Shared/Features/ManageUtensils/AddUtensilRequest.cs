using MediatR;

namespace CookTo.Shared.Features.ManageUtensils;

public record AddUtensilRequest(AddUtensilDto utensil) : IRequest<AddUtensilRequest.Response>
{
    public const string RouteTemplate = "api/Utensil";
    public record Response(UtensilResultDto utensil);
}
