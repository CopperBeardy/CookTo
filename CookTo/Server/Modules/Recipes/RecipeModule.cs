using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;
using Microsoft.Identity.Web;


namespace CookTo.Server.Modules.Recipes;

public class RecipeModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.RECIPE);
        api.MapGet("/{id}", async (string id, IRecipeService service, CancellationToken cancellationToken) =>
        {
            var response = await GetById.Handle(id, service, cancellationToken);
            if(response is null)
                return Results.NotFound(ErrorMessage<Recipe>.ItemNotFound(id));
            return Results.Ok(response);
        });


        api.MapPost("/", async (Recipe recipe, HttpContext context, IRecipeService service, CancellationToken cancellationToken) =>
        {
            recipe.AddedBy = context.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();
            var response = await Post.Handle(recipe, service, cancellationToken);

            return Results.Created($"/{EndpointTemplate.RECIPE}/{recipe.Id}", response);
        })
            .RequireAuthorization();

        api.MapPut("/", async (Recipe recipe, IRecipeService service, CancellationToken cancellationToken) =>
        {
            var response = await Put.Handle(recipe, service, cancellationToken);

            if(response is null)
                return Results.NotFound(ErrorMessage<Recipe>.ItemNotFound(recipe.Id));

            return Results.NoContent();
        })
            .RequireAuthorization();

        api.MapDelete("/{id}", async (string id, IRecipeService service, CancellationToken cancellationToken) =>
        {
            await Delete.Handle(id, service, cancellationToken);
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
