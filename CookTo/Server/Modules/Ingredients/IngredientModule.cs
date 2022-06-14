using AutoMapper;
using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Server.Modules.Ingredients.Services;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Ingredients;

public static class IngredientModule
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
