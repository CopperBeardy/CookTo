using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;

using CookTo.Shared;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Cuisines;


public class CuisineModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CUISINE);
        api.MapGet("/", GetAllCuisines);

        api.MapPost("/", PostCuisine).RequireAuthorization();

        return api;
    }

    internal static async Task<List<Cuisine>> GetAllCuisines(ICuisineService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var cuisines = new List<Cuisine>();

        if (entites is not null || entites.Any())
            cuisines.AddRange(entites.Select(c => new Cuisine { Id = c.Id, Name = c.Name }));

        return cuisines;
    }

    internal static async Task<Cuisine> PostCuisine(Cuisine category, ICuisineService service, CancellationToken cancellationToken)
    {
        var newCuisine = new CuisineDocument() { Name = category.Name };
        await service.CreateAsync(newCuisine, cancellationToken);

        return new Cuisine { Id = newCuisine.Id, Name = newCuisine.Name };
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICuisineService, CuisineService>();
        return services;
    }
}
