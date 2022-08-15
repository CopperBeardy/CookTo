using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Tips.Handlers;

public static class GetByIdHandler
{
    public static async Task<IResult> Handle(string id, CommonParameters cp)
    {
        var document = await cp.TipService.GetByIdAsync(id, cp.CancellationToken);
        if (document is null)
        {
            return Results.BadRequest("Recipe was not found");
        }
        var tip = new Tip { Id = document.Id, Description = document.Description };
        return Results.Ok(tip);
    }
}
