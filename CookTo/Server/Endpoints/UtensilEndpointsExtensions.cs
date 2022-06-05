using AutoMapper;
using CookTo.Server.Documents;

using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features;
using CookTo.Shared.Models;

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
                return Results.Ok(mapper.Map<List<Utensil>>(utensils));
            });
        app.MapPost(
            "/api/utensil",
            async (Utensil utensil, IUtensilService service, IMapper mapper, CancellationToken token) =>
            {
                var newUtensil = mapper.Map<UtensilDocument>(utensil);
                await service.CreateAsync(newUtensil, token);
                return Results.Ok(mapper.Map<Utensil>(newUtensil));
            });
    }
}
