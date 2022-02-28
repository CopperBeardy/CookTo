using AutoMapper;
using CookTo.Server.Documents.RecipeDocument;
using CookTo.Server.Helpers;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageCuisine;
using CookTo.Shared.Features.ManageRecipes;
using Microsoft.Identity.Web;

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
                List<RecipeSummaryDto> recipeSummaries = new List<RecipeSummaryDto>();
                foreach(var recipe in recipes)
                {
                    recipeSummaries.Add(
                        new RecipeSummaryDto(
                            recipe.Id,
                            recipe.Category,
                            recipe.Title,
                            recipe.PrepTimeFrom,
                            recipe.PrepTimeTo,
                            recipe.CookTimeFrom,
                            recipe.CookTimeFrom,
                            mapper.Map<CuisineDto>(recipe.Cuisine),
                            recipe.Image,
                            recipe.AuthorId));
                }
                return Results.Ok(recipeSummaries);
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

        app.MapGet(
            "/api/search/{term}",
            async (string term, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipes = string.Empty;
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
                var toUpdate = RecipeFormatter.Format(mapper.Map<Recipe>(updateRecipe));
                await service.UpdateAsync(toUpdate, token);
                return Results.NoContent();
            });
        app.MapPost(
            "/api/recipe",
            async (
                RecipeDto recipe,
                IRecipeService service,
                IMapper mapper,
                HttpContext context,
                CancellationToken token) =>
            {
                recipe.AuthorId = context.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();
                var entity = RecipeFormatter.Format(mapper.Map<Recipe>(recipe));
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
