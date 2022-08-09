using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Categories.Services;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Utensils.Core;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
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

