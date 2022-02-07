using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageUtensils.AddUtensil;
using CookTo.Shared.Features.ManageUtensils.Shared;

namespace CookTo.Server.Features.ManageUtensils.AddUtensil;

public class AddUtensilEndpoint : EndpointBaseAsync.WithRequest<AddUtensilRequest>.WithActionResult<UtensilDto>
{
    readonly IUtensilService _utensilService;
    readonly IMapper _mapper;
    public AddUtensilEndpoint(IUtensilService utensilService, IMapper mapper) { _utensilService = utensilService;  _mapper = mapper; }

    [HttpPost(AddUtensilRequest.RouteTemplate)]
    public override async Task<ActionResult<UtensilDto>> HandleAsync(
        AddUtensilRequest request,
        CancellationToken cancellationToken = default)
    {
        Utensil utensil = _mapper.Map<Utensil>(request.utensil);
        await _utensilService.CreateAsync(utensil, cancellationToken);
        return Ok(_mapper.Map<UtensilDto>(utensil));
    }
}
