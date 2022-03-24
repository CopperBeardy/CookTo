using AutoMapper;
using CookTo.Server.Documents.UtensilDocument;

using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageUtensils;

namespace CookTo.Server.Endpoints;

public static class UtensilEndpointsExtensions
{
    public static void UtensilEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/utensil",
            async (IUtensilService service, IMapper mapper, CancellationToken token) =>
            {
                var utensils = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<UtensilDto>>(utensils));
            });
        app.MapPost(
            "/api/utensil",
            async (UtensilDto utensil, IUtensilService service, IMapper mapper, CancellationToken token) =>
            {
                var newUtensil = mapper.Map<Utensil>(utensil);
                await service.CreateAsync(newUtensil, token);
                return Results.Ok(mapper.Map<UtensilDto>(newUtensil));
            });
    }
}
