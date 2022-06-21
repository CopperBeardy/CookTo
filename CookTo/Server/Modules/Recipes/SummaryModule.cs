using AutoMapper;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Recipes;

public static class SummaryModule
{
    public static void RecipeSummaryEndpoints(this WebApplication app)
    {
        //todo this will be a curated list by a admin 
        //until implmented the first x amount is retrieved
        app.MapGet(
            "/api/recipes/{amount}",
            async (string amount, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipes = await service.GetByLimit(int.Parse(amount), token);
                List<RecipeSummary> recipeSummaries = new();
                foreach (var recipe in recipes)
                {                   
                    recipeSummaries.Add(
                        new RecipeSummary(
                            recipe.Id,
                            mapper.Map<Category>(recipe.Category),
                            recipe.Title,
                            mapper.Map<Cuisine>(recipe.Cuisine),
                            recipe.Image,
                            string.IsNullOrEmpty(recipe.Creator) ? string.Empty : recipe.Creator,
                            recipe.AddedBy));
                }
                return Results.Ok(recipeSummaries);
            });

        app.MapGet(
            "/api/searchrecipes/{term}",
            async (string term, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipes = await service.GetAllByTerm(term, token);
                List<RecipeSummary> recipeSummaries = new();
                foreach (var recipe in recipes)
                {

                    recipeSummaries.Add(
                        new RecipeSummary(
                            recipe.Id,
                            mapper.Map<Category>(recipe.Category),
                            recipe.Title,
                            mapper.Map<Cuisine>(recipe.Cuisine),
                            recipe.Image,
                            string.IsNullOrEmpty(recipe.Creator) ? string.Empty : recipe.Creator,
                            recipe.AddedBy));

                }
                return Results.Ok(recipeSummaries);
            });
    }
}
