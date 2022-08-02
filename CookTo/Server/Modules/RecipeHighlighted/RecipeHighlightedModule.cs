using CookTo.Server.Modules.RecipeHighlighted.Core;
using CookTo.Server.Modules.RecipeHighlighted.Services;
using CookTo.Shared;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.RecipeHighlighted;

public  class RecipeHighlightedModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/highlighted");

        endpoints.MapGet(
            "/",
            async ( IRecipeHighlightedService service, CancellationToken token) =>
            {
                var entity = await service.GetAsync(token);
                if(entity is null)
                    return Results.NotFound(ErrorMessage<HighlightedRecipeDocument>.ItemNotFound(string.Empty));

                var highlighted = new HighlightedRecipe
                                    (
                                       entity.Id,
                                    new Category { Id = entity.Category.Id, Text = entity.Category.Text },
                                    entity.Title,
                                    new Cuisine { Id = entity.Cuisine.Id, Text = entity.Cuisine.Text },
                                    entity.Image,
                                    entity.Creator,
                                    entity.AddedBy,
                                    entity.PrepTime,
                                    entity.CookTime,
                                    entity.Description,
                                    entity.Dietaries,
                                    entity.ShoppingList,
                                    entity.Tags);
                return Results.Ok(highlighted);
            });

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IRecipeHighlightedService, RecipeHighlightedService>();
        return services;
    }
}
