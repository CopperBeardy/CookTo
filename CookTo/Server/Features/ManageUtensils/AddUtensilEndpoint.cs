using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageUtensils;

namespace CookTo.Server.Features.ManageUtensils;

public class AddUtensilEndpoint : EndpointBaseAsync.WithRequest<AddUtensilRequest>.WithActionResult<UtensilResultDto>
{
    readonly IMapper _mapper;
    readonly IUtensilService _utensilService;

    public AddUtensilEndpoint(IUtensilService utensilService, IMapper mapper)
    {
        _utensilService = utensilService;
        _mapper = mapper;
    }

    [HttpPost(AddUtensilRequest.RouteTemplate)]
    public override async Task<ActionResult<UtensilResultDto>> HandleAsync(
        AddUtensilRequest request,
        CancellationToken cancellationToken = default)
    {
        Utensil utensil = _mapper.Map<Utensil>(request.utensil);
        await _utensilService.CreateAsync(utensil);
        return Ok(_mapper.Map<UtensilResultDto>(utensil));
    }
}
