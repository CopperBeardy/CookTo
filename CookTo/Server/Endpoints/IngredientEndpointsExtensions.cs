using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features;
using CookTo.Shared.Models;

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
                return Results.Ok(mapper.Map<List<Ingredient>>(ingredients));
            });

        app.MapGet(
            "/api/ingredient/{id}",
            async (string id, IIngredientService service, IMapper mapper, CancellationToken token) =>
            {
                var ing = await service.GetByIdAsync(id, token);
                if (ing is null)
                {
                    return Results.BadRequest("Ingredient was not found");
                }

                var response = mapper.Map<Ingredient>(ing);
                return Results.Ok(response);
            });


        app.MapPost(
            "/api/ingredient",
            async (Ingredient ingredient, IIngredientService service, IMapper mapper, CancellationToken token) =>
            {
                var newIngredient = mapper.Map<IngredientDocument>(ingredient);
                await service.CreateAsync(newIngredient, token);
                return Results.Ok(mapper.Map<Ingredient>(newIngredient));
            });
    }
}
