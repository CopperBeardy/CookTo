using AutoMapper;
using CookTo.Server.Modules.Utensils.Core;
using CookTo.Server.Modules.Utensils.Services;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils;

public  class UtensilModule : IModule
{
    public GroupRouteBuilder MapEndpoints(GroupRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/utensil");
        api.MapGet(
            "/",
            async (IUtensilService service, IMapper mapper, CancellationToken token) =>
            {
                var utensils = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<Utensil>>(utensils));
            });
        api.MapPost(
            "/",
            async (Utensil utensil, IUtensilService service, IMapper mapper, CancellationToken token) =>
            {
                var newUtensil = mapper.Map<UtensilDocument>(utensil);
                await service.CreateAsync(newUtensil, token);
                return Results.Ok(mapper.Map<Utensil>(newUtensil));
            })
            .RequireAuthorization();
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IUtensilService, UtensilService>();
        return services;
    }
}
