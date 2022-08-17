using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;
using Microsoft.Identity.Web;


namespace CookTo.Server.Modules.Recipes;

public class RecipeModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.RECIPE);
        api.MapGet("/{id}", async (string id, IRecipeService service, CancellationToken cancellationToken) => await GetById.Handle(id, service, cancellationToken));

        api.MapPost("/", async (Recipe recipe, HttpContext context, IRecipeService service, CancellationToken cancellationToken) =>
        {
            recipe.AddedBy = context.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();
            return await Post.Handle(recipe, service, cancellationToken);
        })
            .RequireAuthorization();

        api.MapPut("/", async (Recipe recipe, IRecipeService service, CancellationToken cancellationToken) => await Put.Handle(recipe, service, cancellationToken))
            .RequireAuthorization();

        api.MapDelete("/{id}", async (string id, IRecipeService service, CancellationToken cancellationToken) => await Delete.Handle(id, service, cancellationToken))
            .RequireAuthorization();

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IRecipeService, RecipeService>();
        return services;
    }
}
