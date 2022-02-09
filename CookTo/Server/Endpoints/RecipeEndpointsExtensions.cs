using AutoMapper;
using CookTo.Server.Documents.RecipeDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Server.Endpoints;

public static class RecipeEndpointsExtensions
{
    public static void RecipeEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/recipe",
            async (IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipes = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<RecipeDto>>(recipes));
            });

        app.MapGet(
            "/api/recipe/{id}",
            async (string id, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipe = await service.GetByIdAsync(id, token);
                if(recipe is null)
                {
                    return Results.BadRequest("Recipe was not found");
                }
                return Results.Ok(mapper.Map<RecipeDto>(recipe));
            });
        app.MapPut(
            "/api/recipe",
            async (RecipeDto updateRecipe, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipe = await service.GetByIdAsync(updateRecipe.Id, token);
                if(recipe is null)
                {
                    return Results.NotFound();
                }
                await service.UpdateAsync(mapper.Map<Recipe>(updateRecipe), token);
                return Results.NoContent();
            });
        app.MapPost(
            "/api/recipe",
            async (RecipeDto recipe, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                await service.CreateAsync(mapper.Map<Recipe>(recipe), token);
                return Results.Created($"/api/recipe/{recipe.Id}", recipe);
            });

        app.MapDelete(
            "/api/recipe/{id}",
            async (string id, IRecipeService service, CancellationToken token) =>
            {
                var recipe = service.GetByIdAsync(id, token);
                if(recipe is null)
                {
                    return Results.NotFound();
                }
                await service.DeleteAsync(id, token);
                return Results.NoContent();
            });
    }
}
