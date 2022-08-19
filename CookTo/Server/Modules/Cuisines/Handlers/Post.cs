using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Cuisines.Handlers;

public static class Post
{
    public static async Task<Cuisine> Handle(Cuisine cuisine, ICuisineService service, CancellationToken cancellationToken)
    {
        var newCuisine = new CuisineDocument() { Name = cuisine.Name };
        await service.CreateAsync(newCuisine, cancellationToken);
        return new Cuisine { Id = newCuisine.Id, Name = newCuisine.Name };
    }
}

