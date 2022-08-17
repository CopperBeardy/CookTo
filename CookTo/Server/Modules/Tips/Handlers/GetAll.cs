using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.DataAccess.Documents.TipDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips.Handlers;

public static class GetAll
{
    public static async Task<IResult> Handle(ITipService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);

        if(entites is null)
            return Results.NotFound(ErrorMessage<TipDocument>.ItemsNotFound());

        var tips = new List<Tip>();
        tips.AddRange(entites.Select(c => new Tip { Id = c.Id, Description = c.Description }));
        return Results.Ok(tips);
    }
}
