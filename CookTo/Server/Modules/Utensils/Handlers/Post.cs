using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess.Services;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Utensils.Handlers;

public static class Post
{
    public static async Task<IResult> Handle(Utensil utensil, IUtensilService service, CancellationToken cancellationToken)
    {
        var newUtensil = new UtensilDocument() { Name = utensil.Name };
        await service.CreateAsync(newUtensil, cancellationToken);
        return Results.Ok(new Utensil { Id = newUtensil.Id, Name = newUtensil.Name });
    }
}

