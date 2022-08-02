using CookTo.Server.Modules.RecipeSummaries.Services;
using CookTo.Shared;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;
using System.Linq;

namespace CookTo.Server.Modules.RecipeSummaries;

public  class RecipeSummaryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/summaries");     

        endpoints.MapGet(
            "/{amount}",
            async (string amount, IRecipeSummaryService service, CancellationToken token) =>
            {        

                var entites = await service.GetByLimit(int.Parse(amount), token);

                if (entites is null)
                    return Results.NotFound(ErrorMessage<RecipeSummary>.ItemsNotFound());

                var summaries = new List<RecipeSummary>();
                summaries.AddRange(entites.Select(recipe => new RecipeSummary
                                    (
                                       recipe.Id,
                                    new Category { Id = recipe.Category.Id, Text = recipe.Category.Text },
                                    recipe.Title,
                                    new Cuisine { Id = recipe.Cuisine.Id, Text = recipe.Cuisine.Text },
                                    recipe.Image,
                                    recipe.Creator,
                                    recipe.AddedBy,
                                    recipe.Dietaries,
                                    recipe.ShoppingList,
                                    recipe.Tags
                                    )));
                return Results.Ok(summaries);

            });   
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IRecipeSummaryService, RecipeSummaryService>();
        return services;
    }
}
