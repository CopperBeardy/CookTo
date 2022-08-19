using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.DataAccess.Documents.TipDocumentAccess.Services;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips.Handlers;

public static class Post
{
    public static async Task<Tip> Handle(Tip tip, ITipService service, CancellationToken cancellationToken)
    {
        var newTip = new TipDocument() { Description = tip.Description };

        await service.CreateAsync(newTip, cancellationToken);

        return new Tip { Id = newTip.Id, Description = newTip.Description };
    }
}

