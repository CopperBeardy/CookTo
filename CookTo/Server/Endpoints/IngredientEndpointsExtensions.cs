using AutoMapper;
using CookTo.Server.Documents.IngredientDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageIngredients.Shared;

namespace CookTo.Server.Endpoints;

public static class IngredientEndpointsExtensions
{
    public static void IngredientEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/ingredient",
            async (IIngredientService service, IMapper mapper, CancellationToken token) =>
            {
                var ingredients = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<IngredientDto>>(ingredients));
            });
        app.MapPost(
            "/api/ingredient",
            async (IngredientDto ingredient, IIngredientService service, IMapper mapper, CancellationToken token) =>
            {
                await service.CreateAsync(mapper.Map<Ingredient>(ingredient), token);
                return Results.Ok(ingredient.Id);
            });
    }
}
