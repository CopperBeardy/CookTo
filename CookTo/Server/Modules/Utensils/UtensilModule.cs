using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils;

public class UtensilModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.UTENSIL);
        api.MapGet("/", GetAllUtensils);
        api.MapPost("/", PostUtensil).RequireAuthorization();

        return api;
    }

    internal static async Task<List<Utensil>> GetAllUtensils(IUtensilService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var utensils = new List<Utensil>();

        if(entites is not null || entites.Any())
            utensils.AddRange(entites.Select(c => new Utensil { Id = c.Id, Name = c.Name }));

        return utensils;
    }

    internal static async Task<Utensil> PostUtensil(Utensil category, IUtensilService service, CancellationToken cancellationToken)
    {
        var newUtensil = new UtensilDocument() { Name = category.Name };
        await service.CreateAsync(newUtensil, cancellationToken);

        return new Utensil { Id = newUtensil.Id, Name = newUtensil.Name };
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IUtensilService, UtensilService>();
        return services;
    }
}
