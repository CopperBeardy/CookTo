using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;
using Microsoft.Identity.Web;


namespace CookTo.Server.Modules.Recipes;

public class RecipeModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.RECIPE);
        api.MapGet("/{id}", async (string id, [AsParameters] CommonParameters cp) => await GetByIdHandler.Handle(id, cp));

        api.MapPost("/", async (Recipe recipe, HttpContext context, [AsParameters] CommonParameters cp) =>
        {
            recipe.AddedBy = context.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();
            return await PostHandler.Handle(recipe, cp);
        })
            .RequireAuthorization();

        api.MapPut("/", async (Recipe recipe, [AsParameters] CommonParameters cp) => await PutHandler.Handle(recipe, cp))
            .RequireAuthorization();

        api.MapDelete("/{id}", async (string id, [AsParameters] CommonParameters cp) => await DeleteHandler.Handle(id, cp))
            .RequireAuthorization();

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IRecipeService, RecipeService>();
        return services;
    }
}
