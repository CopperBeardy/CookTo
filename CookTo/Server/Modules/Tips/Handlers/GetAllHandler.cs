using CookTo.Server.Modules.Tips.Core;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips.Handlers;

public static class GetAllHandler
{
    public static async Task<IResult> Handle(CommonParameters cp)
    {
        var entites = await cp.TipService.GetAllAsync(cp.CancellationToken);

        if (entites is null)
            return Results.NotFound(ErrorMessage<TipDocument>.ItemsNotFound());

        var tips = new List<Tip>();
        tips.AddRange(entites.Select(c => new Tip { Id = c.Id, Description = c.Description }));
        return Results.Ok(tips);
    }
}
