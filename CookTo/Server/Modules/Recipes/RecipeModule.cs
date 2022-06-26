using AutoMapper;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Shared.Modules.ManageSearch;
using Microsoft.Identity.Web;

namespace CookTo.Server.Modules.Recipes;

public  class RecipeModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/api");
        api.MapGet(
            "/recipe/{id}",
            async (string id, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipe = await service.GetByIdAsync(id, token);
                if(recipe is null)
                {
                    return Results.BadRequest("Recipe was not found");
                }
                return Results.Ok(mapper.Map<FullRecipe>(recipe));
            });

        api.MapGet(
            "/highlighted",
            async (IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                //Todo: this is a code smell
                // the hightlight recipe will be set by admin when fully implemented
                // admin area not ready so taking the first recipe all the time

                var recipes = await service.GetAllAsync(token);
                var recipe = recipes.FirstOrDefault();
                //    var recipe = await service.GetByIdAsync("622224f121307568e8720d59", token);

                return Results.Ok(mapper.Map<HighlightedRecipe>(recipe));
            });


        api.MapGet(
            "/recipes/{amount}",
            async (string amount, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipes = await service.GetByLimit(int.Parse(amount), token);
                List<RecipeSummary> recipeSummaries = new();
                recipeSummaries.AddRange(recipes.Select(recipe => mapper.Map<RecipeSummary>(recipe)));
                return Results.Ok(recipeSummaries);
            });

        ////change to take a list of
        //endpoints.MapGet(
        //    "/api/searchrecipes/{searchRequest}",
        //    async (SearchRequest searchRequest, IRecipeService service, IMapper mapper, CancellationToken token) =>
        //    {
        //        //check to see if cuisines or/and Categories has the "All" option selected

        //        var recipes = await service.GetAllByTerm("", token);
        //        List<RecipeSummary> recipeSummaries = new();
        //        recipeSummaries.AddRange(recipes.Select(recipe => mapper.Map<RecipeSummary>(recipe)));
        //        return Results.Ok(recipeSummaries);
        //    });

        api.MapPost(
            "/recipe",
            async (
                FullRecipe recipe,
                IRecipeService service,
                IMapper mapper,
                HttpContext context,
                CancellationToken token) =>
            {
                var entity = mapper.Map<RecipeDocument>(recipe);

                entity.AddedBy = context.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();
                entity.ShoppingList = ShoppingList.Generate(recipe.CookingSteps);
                entity.Tags = TagHelper.GenerateTags(entity);
                await service.CreateAsync(entity, token);

                return Results.Created($"/api/recipe/{entity.Id}", entity);
            })
            .RequireAuthorization();

        api.MapPut(
            "/recipe",
            async (FullRecipe updateRecipe, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                if(updateRecipe.Id is not null)
                {
                    var recipe = await service.GetByIdAsync(updateRecipe.Id, token);
                    if(recipe is null)
                    {
                        return Results.NotFound();
                    }
                    var toUpdate = mapper.Map<RecipeDocument>(updateRecipe);
                    toUpdate.ShoppingList.Clear();
                    toUpdate.ShoppingList = ShoppingList.Generate(updateRecipe.CookingSteps);

                    toUpdate.Tags = TagHelper.GenerateTags(toUpdate);

                    await service.UpdateAsync(toUpdate, token);
                    return Results.NoContent();
                }
                return Results.BadRequest();
            })
            .RequireAuthorization();

        api.MapDelete(
            "/recipe/{id}",
            async (string id, IRecipeService service, CancellationToken token) =>
            {
                var recipe = service.GetByIdAsync(id, token);
                if(recipe is null)
                {
                    return Results.NotFound();
                }
                await service.DeleteAsync(id, token);
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
