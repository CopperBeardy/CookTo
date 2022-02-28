using AutoMapper;
using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Helpers;
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
                var ingredients = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<UtensilDto>>(ingredients));
            });
        app.MapPost(
            "/api/utensil",
            async (UtensilDto utensil, IUtensilService service, IMapper mapper, CancellationToken token) =>
            {
                var   newUtensil = UtensilFormatter.Format(mapper.Map<Utensil>(utensil));
                await service.CreateAsync(newUtensil, token);
                return Results.Ok(mapper.Map<UtensilDto>(newUtensil));
            });
    }
}
