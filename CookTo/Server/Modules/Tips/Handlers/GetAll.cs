using CookTo.DataAccess.Documents.TipDocumentAccess.Services;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips.Handlers;

public static class GetAll
{
    public static async Task<List<Tip>?> Handle(ITipService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var tips = new List<Tip>();

        if(entites is not null || entites.Any())
            tips.AddRange(entites.Select(c => new Tip { Id = c.Id, Description = c.Description }));

        return tips;
    }
}
