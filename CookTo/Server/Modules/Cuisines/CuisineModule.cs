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

    internal static async Task<IResult> GetAllCuisines(ICuisineService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var response = new List<Cuisine>();

        if(entites is not null || entites.Any())
            response.AddRange(entites.Select(c => new Cuisine { Id = c.Id, Name = c.Name }));

        return TypedResults.Ok(response);
    }

    internal static async Task<IResult> PostCuisine(Cuisine category, ICuisineService service, CancellationToken cancellationToken)
    {
        var newCuisine = new CuisineDocument() { Name = category.Name };
        await service.CreateAsync(newCuisine, cancellationToken);
        var response = new Cuisine { Id = newCuisine.Id, Name = newCuisine.Name };
        return TypedResults.Ok(response);
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICuisineService, CuisineService>();
        return services;
    }
}
