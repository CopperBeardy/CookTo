using CookTo.Server.Modules.Utensils.Core;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageUtensils;


namespace CookTo.Server.Modules.Utensils.Handlers;

public static class GetAllHandler
{
    public static async Task<IResult> Handle(CommonParameters cp)
    {
        var entites = await cp.UtensilService.GetAllAsync(cp.CancellationToken);

        if (entites is null)
            return Results.NotFound(ErrorMessage<UtensilDocument>.ItemsNotFound());

        var utensil = new List<Utensil>();
        utensil.AddRange(entites.Select(c => new Utensil { Id = c.Id, Text = c.Text }));
        return Results.Ok(utensil);
    }
}
