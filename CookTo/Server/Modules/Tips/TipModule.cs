using CookTo.DataAccess.Documents.TipDocumentAccess.Services;
using CookTo.Server.Modules.Tips.Handlers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips;

public class TipModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.TIP);
        api.MapGet("/", async (ITipService service, CancellationToken cancellationToken) =>
        {
            var response = await GetAll.Handle(service, cancellationToken);
            return Results.Ok(response);
        });


        api.MapPost("/", async (Tip tip, ITipService service, CancellationToken cancellationToken) =>
        {
            var response = await Post.Handle(tip, service, cancellationToken);
            return Results.Ok(response);
        })
            .RequireAuthorization();

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ITipService, TipService>();
        return services;
    }
}
