using AutoMapper;
using CookTo.Server.Helpers;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes;
using Microsoft.Identity.Web;

namespace CookTo.Server.Endpoints;

public static class RecipeEndpointsExtensions
{
    public static void RecipeEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/recipe/{id}",
            async (string id, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipe = await service.GetByIdAsync(id, token);
                if(recipe is null)
                {
                    return Results.BadRequest("Recipe was not found");
                }
                return Results.Ok(mapper.Map<FullRecipe>(recipe));
            });

        app.MapPut(
            "/api/recipe",
            async (FullRecipe updateRecipe, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipe = await service.GetByIdAsync(updateRecipe.Id, token);
                if(recipe is null)
                {
                    return Results.NotFound();
                }
                var toUpdate = mapper.Map<Documents.RecipeDocument>(updateRecipe);
               toUpdate.ShoppingList = ShoppingList.Generate(updateRecipe.CookingSteps);
                await service.UpdateAsync(toUpdate, token);
                return Results.NoContent();
            });

        app.MapPost(
            "/api/recipe",
            async (
                FullRecipe recipe,
                IRecipeService service,
                IMapper mapper,
                HttpContext context,
                CancellationToken token) =>
            {
                var entity = mapper.Map<Documents.RecipeDocument>(recipe);
                entity.AddedBy = context.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();
                entity.ShoppingList = ShoppingList.Generate(recipe.CookingSteps);
                await service.CreateAsync(entity, token);

                return Results.Created($"/api/recipe/{entity.Id}", entity);
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
