using AutoMapper;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Ingredients;

public class IngredientModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.INGREDIENT);
        api.MapGet("/{Id}", GetByIdIngredient);
        api.MapGet("/", GetAllIngredients);
        api.MapPost("/", PostIngredient).RequireAuthorization();
        return api;
    }

    internal record Request(IIngredientService IngredientService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetByIdIngredient(string id, [AsParameters] Request request) => await GenericHandlers<IngredientDocument, Ingredient>
    .GetByIdAsync(id, request.IngredientService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> GetAllIngredients([AsParameters] Request request) => await GenericHandlers<IngredientDocument, Ingredient>
        .GetAllAsync(request.IngredientService, request.CancellationToken, request.Mapper);

    internal static async Task<IResult> PostIngredient(Ingredient category, [AsParameters] Request request) => await GenericHandlers<IngredientDocument, Ingredient>
        .PostAsync(category, request.IngredientService, request.CancellationToken, request.Mapper, EndpointTemplate.CATEGORY_GET_REDIRECT);


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IIngredientService, IngredientService>();
        return services;
    }
}
