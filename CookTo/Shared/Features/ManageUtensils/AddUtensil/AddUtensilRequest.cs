using CookTo.Shared.Features.ManageUtensils.Shared;
using MediatR;

namespace CookTo.Shared.Features.ManageUtensils.AddUtensil;

public record AddUtensilRequest(UtensilDto utensil) : IRequest<AddUtensilRequest.Response>
{
    public const string RouteTemplate = "api/Utensil";
    public record Response(UtensilDto utensil);
}
