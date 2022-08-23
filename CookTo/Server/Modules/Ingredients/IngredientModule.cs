using AutoMapper;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Ingredients;

public class IngredientModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.INGREDIENT);
        api.MapGet("/", GetAllIngredients);
        api.MapGet("/{Id}", GetByIdIngredient);
        api.MapPost("/", PostIngredient).RequireAuthorization();
        return api;
    }

    internal record Request(IIngredientService IngredientService, IMapper Mapper, CancellationToken CancellationToken);

    internal static async Task<IResult> GetAllIngredients([AsParameters] Request request)
    {
        var entites = await request.IngredientService.GetAllAsync(request.CancellationToken);
        var ingredients = new List<Ingredient>();

        if(entites is not null || entites.Any())
            ingredients.AddRange(entites.Select(c => request.Mapper.Map<Ingredient>(c)));

        return TypedResults.Ok(ingredients);
    }

    internal static async Task<IResult> GetByIdIngredient(string id, [AsParameters] Request request)
    {
        var document = await request.IngredientService.GetByIdAsync(id, request.CancellationToken);
        if(document is null)
            return TypedResults.NotFound(ErrorMessage<Ingredient>.ItemNotFound(id));

        var response = request.Mapper.Map<Ingredient>(document);
        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> PostIngredient(Ingredient category, [AsParameters] Request request)
    {
        var document = request.Mapper.Map<IngredientDocument>(category);
        await request.IngredientService.CreateAsync(document, request.CancellationToken);
        var response = request.Mapper.Map<Ingredient>(document);
        return TypedResults.Created($"{EndpointTemplate.CATEGORY_REDIRECT}/{response.Id}", response);
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IIngredientService, IngredientService>();
        return services;
    }
}
