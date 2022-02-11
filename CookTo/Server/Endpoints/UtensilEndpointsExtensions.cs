using AutoMapper;
using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageUtensils;
using Microsoft.AspNetCore.Authorization;

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
                await service.CreateAsync(mapper.Map<Utensil>(utensil), token);
                return Results.Ok(utensil.Id);
            });
    }
}
