using AutoMapper;
using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Recipes;

public class RecipeHighlightedModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.HIGHLIGHTED);

        api.MapGet("/", GetHighlighted);

        return api;
    }

    internal record Request(IRecipeService RecipeService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetHighlighted([AsParameters] Request request)
    {
        var recipe = await request.RecipeService.GetHighlighted(request.CancellationToken);

        var highlighted = new HighlightedRecipe()
        {
            Id = recipe.Id,
            Category = new Category { Id = recipe.Id, Name = recipe.Category.Name },
            Title = recipe.Title,
            Cuisine = new Cuisine { Id = recipe.Cuisine.Id, Name = recipe.Cuisine.Name },
            Image = recipe.Image,
            Creator = recipe.Creator,
            AddedBy = recipe.AddedBy,
            PrepTime = recipe.PrepTime,
            CookTime = recipe.CookTime,
            Description = recipe.Description,
            Dietaries = recipe.Dietaries,
            ShoppingList = recipe.ShoppingList,
            Tags = recipe.Tags
        };

        return TypedResults.Ok(highlighted);
    }


    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}
