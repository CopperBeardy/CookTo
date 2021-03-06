using AutoMapper;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Cuisines.Services;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Cuisines;

public class CuisineModule : IModule
{
    public GroupRouteBuilder MapEndpoints(GroupRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/cuisine");
        api.MapGet(
            "/",
            async (ICuisineService service, IMapper mapper, CancellationToken token) =>
            {
                var cuisines = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<Cuisine>>(cuisines));
            });

        api.MapGet(
            "/{id}",
            async (string id, ICuisineService service, IMapper mapper, CancellationToken token) =>
            {
                var cuisine = await service.GetByIdAsync(id, token);
                if(cuisine is null)
                {
                    return Results.BadRequest("Cuisine was not found");
                }

                var response = mapper.Map<Cuisine>(cuisine);
                return Results.Ok(response);
            });


        api.MapPost(
            "/",
            async (Cuisine cuisine, ICuisineService service, IMapper mapper, CancellationToken token) =>
            {
                var newCuisine = mapper.Map<CuisineDocument>(cuisine);
                await service.CreateAsync(newCuisine, token);
                return Results.Ok(mapper.Map<Cuisine>(newCuisine));
            })
            .RequireAuthorization();
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ICuisineService, CuisineService>();
        return services;
    }
}
