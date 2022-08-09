using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Cuisines.Handlers;
using CookTo.Server.Modules.Cuisines.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Cuisines;

public class CuisineModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.CUISINE);
        api.MapGet(  "/", async ([AsParameters]CommonParameters cp) => await GetAllHandler.Handle(cp));

        api.MapPost("/", async (Cuisine cuisine, [AsParameters] CommonParameters cp) => await PostHandler.Handle(cuisine, cp))
            .RequireAuthorization();
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICuisineService, CuisineService>();
        return services;
    }
}
