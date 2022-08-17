using AutoMapper;
using CookTo.DataAccess.Documents.UtensilDocumentAccess.Services;
using CookTo.Server.Modules.Utensils.Handlers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils;

public class UtensilModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.UTENSIL);
        api.MapGet(
            "/",
            async (IUtensilService service, CancellationToken cancellationToken) => await GetAll.Handle(service, cancellationToken));
        api.MapPost(
            "/",
            async (Utensil utensil, IUtensilService service, CancellationToken cancellationToken) => await Post.Handle(utensil, service, cancellationToken))
            .RequireAuthorization();
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IUtensilService, UtensilService>();
        return services;
    }
}
