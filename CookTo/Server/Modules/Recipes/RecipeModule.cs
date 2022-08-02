using AutoMapper;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Server.Modules.RecipeSummaries.Core;
using CookTo.Server.Modules.RecipeSummaries.Services;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageRecipes;
using Microsoft.Identity.Web;
using SharpCompress.Common;

namespace CookTo.Server.Modules.Recipes;

public  class RecipeModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/recipe");
        api.MapGet(
            "/{id}",
            async (string id, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipe = await service.GetByIdAsync(id, token);
                if(recipe is null)
                {
                    return Results.BadRequest("Recipe was not found");
                }
                return Results.Ok(mapper.Map<Recipe>(recipe));
            });

        api.MapPost(
            "/",
            async (
                Recipe recipe,
                IRecipeService service,
                IRecipeSummaryService summaryService,               
                HttpContext context,
                CancellationToken token) =>
            {
                recipe.AddedBy = context.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();

                var entity = RecipeToRecipeDocumentConverter.Convert(recipe);
                await service.CreateAsync(entity, token);

                var summary = new RecipeSummaryDocument(entity.Id, entity.Title, entity.Category, entity.Cuisine, entity.Image, entity.Creator, entity.AddedBy, entity.Dietaries, entity.ShoppingList, entity.Tags);
                await summaryService.CreateAsync(summary, token);

                return Results.Created($"/api/recipe/{entity.Id}", entity);
            })
            .RequireAuthorization();

        api.MapPut(
            "/",
            async (Recipe updateRecipe, IRecipeService service, IRecipeSummaryService summaryService , CancellationToken token) =>
            {
                if(updateRecipe.Id is not null)
                {
                    var toUpdateRecipe = RecipeToRecipeDocumentConverter.Convert(updateRecipe);
                    await service.UpdateAsync(toUpdateRecipe, token);

                    var toUpdateSummary = new RecipeSummaryDocument(toUpdateRecipe.Id, toUpdateRecipe.Title, toUpdateRecipe.Category, toUpdateRecipe.Cuisine, toUpdateRecipe.Image, toUpdateRecipe.Creator, toUpdateRecipe.AddedBy, toUpdateRecipe.Dietaries, toUpdateRecipe.ShoppingList, toUpdateRecipe.Tags);
                    await summaryService.UpdateAsync(toUpdateSummary, token);

                    return Results.NoContent();
                }
                return Results.BadRequest();
            })
            .RequireAuthorization();
        api.MapDelete(
        "/{id}",
        async (string id, IRecipeService service, IRecipeSummaryService summaryService, CancellationToken token) =>
        {
            var recipe = await service.GetByIdAsync(id, token);
            if(recipe is null)
            {
                return Results.NotFound();
            }
            await service.DeleteAsync(id, token);

            await summaryService.DeleteAsync(id, token);


            return Results.NoContent();
        })
            .RequireAuthorization();
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IRecipeService, RecipeService>();
        return services;
    }
}
