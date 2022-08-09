using CookTo.Server.Modules.Tips.Core;
using CookTo.Server.Modules.Tips.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips;

public class TipModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.TIP);
        api.MapGet(
            "/",
            async (ITipService service, CancellationToken token) =>
            {
                var entites = await service.GetAllAsync(token);

                if(entites is null)
                    return Results.NotFound(ErrorMessage<Tip>.ItemsNotFound());

                var categories = new List<Tip>();
                categories.AddRange(entites.Select(c => new Tip { Id = c.Id, Description = c.Text }));
                return Results.Ok(categories);
            });

        api.MapGet(
            "/{id}",
            async (string id, ITipService service, CancellationToken token) =>
            {
                var entity = await service.GetByIdAsync(id, token);
                if(entity is null)
                    return Results.NotFound(ErrorMessage<Tip>.ItemNotFound(id));

                var catergory = new Tip { Id = entity.Id, Description = entity.Text };
                return Results.Ok(catergory);
            });


        api.MapPost(
            "/",
            async (Tip tip, ITipService service, CancellationToken token) =>
            {
                var newTip = new TipDocument() { Text = tip.Description };
                await service.CreateAsync(newTip, token);
                return Results.Ok(new Tip { Id = newTip.Id, Description = newTip.Text });
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
