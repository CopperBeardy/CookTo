using AutoMapper;
using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Recipes;

public class RecipeSummaryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.SUMMARY);
        api.MapGet("/{amount}", GetSummaries);
        return api;
    }

    internal record Request(IRecipeService RecipeService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetSummaries(int amount, [AsParameters] Request request)
    {
        var response = await request.RecipeService.GetSummaries(amount, request.CancellationToken, 0);
        var summaries = new List<RecipeSummary>();
        if(response is not null || response.Any())

            summaries.AddRange(response.Select(recipe => new RecipeSummary(
                recipe.Id,
                new Category { Id = recipe.Id, Name = recipe.Category.Name },
                recipe.Title,
                new Cuisine { Id = recipe.Cuisine.Id, Name = recipe.Cuisine.Name },
                recipe.Image,
                recipe.Creator,
                recipe.AddedBy,
                recipe.Dietaries,
                recipe.ShoppingList,
                recipe.Tags)));
        return TypedResults.Ok(summaries);
    }


    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}
