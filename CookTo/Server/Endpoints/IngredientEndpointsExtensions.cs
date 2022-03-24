using AutoMapper;
using CookTo.Server.Documents.IngredientDocument;

using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageIngredients;

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

        app.MapGet(
            "/api/ingredient/{id}",
            async (string id, IIngredientService service, IMapper mapper, CancellationToken token) =>
            {
                var ing = await service.GetByIdAsync(id, token);
                if (ing is null)
                {
                    return Results.BadRequest("Ingredient was not found");
                }

                var response = mapper.Map<IngredientDto>(ing);
                return Results.Ok(response);
            });


        app.MapPost(
            "/api/ingredient",
            async (IngredientDto ingredient, IIngredientService service, IMapper mapper, CancellationToken token) =>
            {
                var newIngredient = mapper.Map<Ingredient>(ingredient);
                await service.CreateAsync(newIngredient, token);
                return Results.Ok(mapper.Map<IngredientDto>(newIngredient));
            });
    }
}
