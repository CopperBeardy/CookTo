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
        api.MapPost("/", PostIngredient).RequireAuthorization();
        return api;
    }

    internal static async Task<List<Ingredient>> GetAllIngredients(IIngredientService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var ingredients = new List<Ingredient>();

        if (entites is not null || entites.Any())
            ingredients.AddRange(entites.Select(c => new Ingredient { Id = c.Id, Name = c.Name }));

        return ingredients;
    }

    internal static async Task<Ingredient> PostIngredient(Ingredient category, IIngredientService service, CancellationToken cancellationToken)
    {
        var newIngredient = new IngredientDocument() { Name = category.Name };
        await service.CreateAsync(newIngredient, cancellationToken);

        return new Ingredient { Id = newIngredient.Id, Name = newIngredient.Name };
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IIngredientService, IngredientService>();
        return services;
    }
}
