using CookTo.Server.Modules.Tips.Core;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips.Handlers;

public static class PostHandler
{
    public static async Task<IResult> Handle(Tip tip, CommonParameters common)
    {
        var newTip = new TipDocument() { Description = tip.Description };
        await common.TipService.CreateAsync(newTip, common.CancellationToken);
        return Results.Ok(new Ingredient { Id = newTip.Id, Text = newTip.Description });
    }
}

