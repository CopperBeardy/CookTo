using AutoMapper;
using CookTo.Server.Modules.Utensils.Core;
using CookTo.Server.Modules.Utensils.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils;

public class UtensilModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("/utensil");
        api.MapGet(
            "/",
            async (IUtensilService service, CancellationToken token) =>
            {
                var entites = await service.GetAllAsync(token);

                if (entites is null)
                    return Results.NotFound(ErrorMessage<Utensil>.ItemsNotFound());

                var utensils = new List<Utensil>();
                utensils.AddRange(entites.Select(c => new Utensil { Id = c.Id, Text = c.Text }));
                return Results.Ok(utensils);
            });
        api.MapPost(
            "/",
            async (Utensil utensil, IUtensilService service, IMapper mapper, CancellationToken token) =>
            {
                var newUtensil = new UtensilDocument { Text = utensil.Text };
                await service.CreateAsync(newUtensil, token);
                return Results.Ok(new Utensil { Id = newUtensil.Id, Text = newUtensil.Text });
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
