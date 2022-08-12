using CookTo.Server.Modules.Utensils.Core;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils.Handlers;

public static class PostHandler
{
    public static async Task<IResult> Handle(Utensil utensil, CommonParameters common)
    {
        var newUtensil = new UtensilDocument() { Text = utensil.Text };
        await common.UtensilService.CreateAsync(newUtensil, common.CancellationToken);
        return Results.Ok(new Utensil { Id = newUtensil.Id, Text = newUtensil.Text });
    }
}

