using Ardalis.ApiEndpoints;
using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageUtensils.AddUtensil;
using CookTo.Shared.Features.ManageUtensils.Shared;

namespace CookTo.Server.Features.ManageUtensils.AddUtensil;

public class AddUtensilEndpoint : EndpointBaseAsync.WithRequest<AddUtensilRequest>.WithActionResult<UtensilDto>
{
    readonly IUtensilService _utensilService;

    public AddUtensilEndpoint(IUtensilService utensilService) { _utensilService = utensilService; }

    [HttpPost(AddUtensilRequest.RouteTemplate)]
    public override async Task<ActionResult<UtensilDto>> HandleAsync(
        AddUtensilRequest request,
        CancellationToken cancellationToken = default)
    {
        Utensil utensil = UtensilMapping.FromDtoToUtensil(request.utensil);
        await _utensilService.CreateAsync(utensil, cancellationToken);
        return Ok(UtensilMapping.FromUtensilToDto(utensil));
    }
}
