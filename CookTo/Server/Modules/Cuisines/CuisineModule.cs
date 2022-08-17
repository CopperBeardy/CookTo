using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.Server.Modules.Cuisines.Handlers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Cuisines;

public class CuisineModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CUISINE);
        api.MapGet("/", async (ICuisineService service, CancellationToken cancellationToken) => await GetAll.Handle(service, cancellationToken));

        api.MapPost("/", async (Cuisine cuisine, ICuisineService service, CancellationToken cancellationToken) => await Post.Handle(cuisine, service, cancellationToken))
            .RequireAuthorization();
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICuisineService, CuisineService>();
        return services;
    }
}
