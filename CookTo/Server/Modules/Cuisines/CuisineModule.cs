using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Cuisines.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Cuisines;

public class CuisineModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/cuisine");
        api.MapGet(
            "/",
            async (ICuisineService service, CancellationToken token) =>
            {
                var entites = await service.GetAllAsync(token);

                if (entites is null)
                    return Results.NotFound(ErrorMessage<Ingredient>.ItemsNotFound());

                var cuisines = new List<Cuisine>();
                cuisines.AddRange(entites.Select(c => new Cuisine { Id = c.Id, Text = c.Text }));
                return Results.Ok(cuisines);
            });

        api.MapPost(
            "/",
            async (Cuisine cuisine, ICuisineService service, CancellationToken token) =>
            {
                var newCuisine = new CuisineDocument { Text = cuisine.Text };
                await service.CreateAsync(newCuisine, token);
                return Results.Ok(new Cuisine { Id = newCuisine.Id, Text = newCuisine.Text });
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
