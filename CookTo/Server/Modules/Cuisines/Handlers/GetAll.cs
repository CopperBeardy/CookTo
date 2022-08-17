using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCuisines;


namespace CookTo.Server.Modules.Cuisines.Handlers;

public static class GetAll
{
    public static async Task<IResult> Handle(ICuisineService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);

        if(entites is null)
            return Results.NotFound(ErrorMessage<CuisineDocument>.ItemsNotFound());

        var cuisines = new List<Cuisine>();
        cuisines.AddRange(entites.Select(c => new Cuisine { Id = c.Id, Name = c.Name }));
        return Results.Ok(cuisines);
    }
}
