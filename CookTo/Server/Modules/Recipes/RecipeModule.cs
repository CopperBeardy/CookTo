using AutoMapper;
using CookTo.DataAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;
using Microsoft.Identity.Web;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace CookTo.Server.Modules.Recipes;

public class RecipeModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.RECIPE);
        api.MapGet("/{id}", GetByIdRecipe);
        api.MapPost("/", PostRecipe).RequireAuthorization();
        api.MapPut("/", PutRecipe).RequireAuthorization();
        api.MapDelete("/{id}", DeleteRecipe).RequireAuthorization();

        return api;
    }

    internal record Request(IRecipeService RecipeService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetByIdRecipe(string id, [AsParameters] Request request)
    {
        var document = await request.RecipeService.GetByIdAsync(id, request.CancellationToken);
        if(document is null)
            return TypedResults.NotFound(ErrorMessage<Recipe>.ItemNotFound(id));

        var response = request.Mapper.Map<Recipe>(document);
        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> PostRecipe(Recipe recipe, HttpContext httpContext, [AsParameters] Request request)
    {
        recipe.AddedBy = httpContext.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();

        var document = request.Mapper.Map<RecipeDocument>(recipe);
        document.ShoppingList.Clear();
        document.ShoppingList = ShoppingListGenerator.Generate(document.ShoppingItems);
        await request.RecipeService.CreateAsync(document, request.CancellationToken);
        var response = request.Mapper.Map<Recipe>(document);
        ;
        return TypedResults.Created($"{EndpointTemplate.RECIPE_REDIRECT}/{recipe.Id}", response);
    }

    internal static async Task<IResult> PutRecipe(Recipe recipe, [AsParameters] Request request)
    {
        var exisitingRecipe = await request.RecipeService.GetByIdAsync(recipe.Id, request.CancellationToken);
        if(exisitingRecipe is null)
            return TypedResults.NotFound(ErrorMessage<Recipe>.ItemNotFound(recipe.Id));

        var document = request.Mapper.Map<RecipeDocument>(recipe);
        document.ShoppingList.Clear();
        document.ShoppingList = ShoppingListGenerator.Generate(document.ShoppingItems);
        await request.RecipeService.UpdateAsync(document, request.CancellationToken);
        var response = request.Mapper.Map<Recipe>(document);
        return TypedResults.Created($"{EndpointTemplate.RECIPE_REDIRECT}/{recipe.Id}", response);
    }

    internal static async Task<IResult> DeleteRecipe(string id, [AsParameters] Request request)
    {
        var recipe = await request.RecipeService.GetByIdAsync(id, request.CancellationToken);
        if(recipe is null)
            return TypedResults.NotFound(ErrorMessage<Recipe>.ItemNotFound(id));
        await request.RecipeService.DeleteAsync(id, request.CancellationToken);
        return TypedResults.NoContent();
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IRecipeService, RecipeService>();
        return services;
    }
}
