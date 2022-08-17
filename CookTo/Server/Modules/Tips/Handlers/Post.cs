using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.DataAccess.Documents.TipDocumentAccess.Services;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips.Handlers;

public static class Post
{
    public static async Task<IResult> Handle(Tip tip, ITipService service, CancellationToken cancellationToken)
    {
        var newTip = new TipDocument() { Description = tip.Description };
        await service.CreateAsync(newTip, cancellationToken);
        return Results.Ok(new Ingredient { Id = newTip.Id, Name = newTip.Description });
    }
}

