using AutoMapper;
using CookTo.DataAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;
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

    internal static async Task<IResult> GetByIdRecipe(string id, [AsParameters] Request request) => await GenericHandlers<RecipeDocument, Recipe>
        .GetByIdAsync(id, request.RecipeService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> PostRecipe(Recipe recipe, HttpContext httpContext, [AsParameters] Request request)
    {
        // need to change this to iterate over the recipePArts
        recipe.ShoppingList.Clear();
        recipe.ShoppingList = ShoppingListGenerator.Generate(recipe.ShoppingItems);
        return   await GenericHandlers<RecipeDocument, Recipe>
        .PostAsync(recipe, request.RecipeService, request.CancellationToken, request.Mapper, EndpointTemplate.RECIPE_GET_REDIRECT);
    }

    internal static async Task<IResult> PutRecipe(Recipe recipe, HttpContext httpContext, [AsParameters] Request request)
    {
        // need to change this to iterate over the recipePArts
        recipe.ShoppingList.Clear();
        recipe.ShoppingList = ShoppingListGenerator.Generate(recipe.ShoppingItems);
        return await GenericHandlers<RecipeDocument, Recipe>
           .PutAsync(recipe, request.RecipeService, request.CancellationToken, request.Mapper, EndpointTemplate.RECIPE_GET_REDIRECT);
    }

    internal static async Task<IResult> DeleteRecipe(string id, [AsParameters] Request request) => await GenericHandlers<RecipeDocument, Recipe>
        .DeleteAsync(id, request.RecipeService, request.CancellationToken, request.Mapper);


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IRecipeService, RecipeService>();
        return services;
    }
}
