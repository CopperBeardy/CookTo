using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCuisines;


namespace CookTo.Server.Modules.Cuisines.Handlers;

public static class GetAll
{
    public static async Task<List<Cuisine>?> Handle(ICuisineService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var cuisines = new List<Cuisine>();

        if(entites is not null || entites.Any())
            cuisines.AddRange(entites.Select(c => new Cuisine { Id = c.Id, Name = c.Name }));

        return cuisines;
    }
}
