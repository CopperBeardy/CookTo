using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.DataAccess.Documents.TipDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;


namespace CookTo.Server.Modules.Tips;

public class TipModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.TIP);
        api.MapGet("/", GetAllTips);
        api.MapPost("/", PostTip).RequireAuthorization();
        return api;
    }

    internal static async Task<List<Tip>> GetAllTips(ITipService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var tips = new List<Tip>();

        if (entites is not null || entites.Any())
            tips.AddRange(entites.Select(c => new Tip { Id = c.Id, Description = c.Description }));

        return tips;
    }

    internal static async Task<Tip> PostTip(Tip category, ITipService service, CancellationToken cancellationToken)
    {
        var newTip = new TipDocument() { Description = category.Description };
        await service.CreateAsync(newTip, cancellationToken);

        return new Tip { Id = newTip.Id, Description = newTip.Description };
    }


    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ITipService, TipService>();
        return services;
    }
}
