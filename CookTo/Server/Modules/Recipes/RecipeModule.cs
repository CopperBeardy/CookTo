using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageRecipes;
using Microsoft.Identity.Web;


namespace CookTo.Server.Modules.Recipes;

public class RecipeModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/recipes");
        api.MapGet(
            "/{id}",
            async (string id, IRecipeService service, CancellationToken token) =>
            {
                var document = await service.GetByIdAsync(id, token);
                if (document is null)
                {
                    return Results.BadRequest("Recipe was not found");
                }
                var recipe = RecipeDocumentToRecipeConverter.Convert(document);
                return Results.Ok(recipe);
            });

        api.MapGet(
          "/highlighted",
          async (IRecipeService service, CancellationToken token) =>
          {
              var recipe = await service.GetHighlighted(token);
              if (recipe is null)
              {
                  return Results.BadRequest("Recipe was not found");
              }

              var highlighted = new HighlightedRecipe(
                  recipe.Id,
                  new Category { Id = recipe.Id, Text = recipe.Category.Text },
                  recipe.Title,
                  new Cuisine { Id = recipe.Cuisine.Id, Text = recipe.Cuisine.Text },
                  recipe.Image,
                  recipe.Creator,
                  recipe.AddedBy,
                  recipe.PrepTime,
                  recipe.CookTime,
                  recipe.Description,
                  recipe.Dietaries,
                  recipe.ShoppingList,
                  recipe.Tags);
              return Results.Ok(highlighted);
          });

        api.MapGet(
   "/summaries/{amount}",
   async (int amount, IRecipeService service, CancellationToken token) =>
   {
       var recipes = await service.GetSummaries(amount, token, 0);
       if (recipes is null || recipes.Count == 0)
       {
           return Results.BadRequest("Recipe was not found");
       }
       var summaries = new List<RecipeSummary>();
       summaries.AddRange(recipes.Select(recipe => new RecipeSummary(
                      recipe.Id,
                      new Category { Id = recipe.Id, Text = recipe.Category.Text },
                      recipe.Title,
                      new Cuisine { Id = recipe.Cuisine.Id, Text = recipe.Cuisine.Text },
                      recipe.Image,
                      recipe.Creator,
                      recipe.AddedBy,
                      recipe.Dietaries,
                      recipe.ShoppingList,
                      recipe.Tags)));
       return Results.Ok(summaries);
   });


        api.MapPost(
            "/",
            async (
                Recipe recipe,
                IRecipeService service,
                HttpContext context,
                CancellationToken token) =>
            {
                recipe.AddedBy = context.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();

                var entity = RecipeToRecipeDocumentConverter.Convert(recipe);
                await service.CreateAsync(entity, token);


                return Results.Created($"/api/recipe/{entity.Id}", entity);
            })
            .RequireAuthorization();

        api.MapPut(
            "/",
            async (Recipe updateRecipe, IRecipeService service, CancellationToken token) =>
            {
                if (updateRecipe.Id is not null)
                {
                    var toUpdateRecipe = RecipeToRecipeDocumentConverter.Convert(updateRecipe);
                    await service.UpdateAsync(toUpdateRecipe, token);

                    return Results.NoContent();
                }
                return Results.BadRequest();
            })
            .RequireAuthorization();

        api.MapDelete(
        "/{id}",
        async (string id, IRecipeService service, CancellationToken token) =>
        {
            var recipe = await service.GetByIdAsync(id, token);
            if (recipe is null)
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
