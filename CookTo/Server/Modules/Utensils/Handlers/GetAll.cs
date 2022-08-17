using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageUtensils;


namespace CookTo.Server.Modules.Utensils.Handlers;

public static class GetAll
{
    public static async Task<IResult> Handle(IUtensilService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);

        if(entites is null)
            return Results.NotFound(ErrorMessage<UtensilDocument>.ItemsNotFound());

        var utensil = new List<Utensil>();
        utensil.AddRange(entites.Select(c => new Utensil { Id = c.Id, Name = c.Name }));
        return Results.Ok(utensil);
    }
}
