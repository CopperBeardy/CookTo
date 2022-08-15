using CookTo.Server.Modules.Tips.Handlers;
using CookTo.Server.Modules.Tips.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips;

public class TipModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.TIP);
        api.MapGet("/", async ([AsParameters] CommonParameters cp) => await GetAllHandler.Handle(cp));

        api.MapGet("/{id}", async (string id, [AsParameters] CommonParameters cp) => await GetByIdHandler.Handle(id, cp));

        api.MapPost("/", async (Tip tip, [AsParameters] CommonParameters cp) => await PostHandler.Handle(tip, cp))
            .RequireAuthorization();

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ITipService, TipService>();
        return services;
    }
}
