using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageUtensils;


namespace CookTo.Server.Modules.Utensils.Handlers;

public static class GetAll
{
    public static async Task<List<Utensil>> Handle(IUtensilService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);

        var utensil = new List<Utensil>();

        if(entites is not null || entites.Any())
            utensil.AddRange(entites.Select(c => new Utensil { Id = c.Id, Name = c.Name }));

        return utensil;
    }
}
