using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;


namespace CookTo.Server.Modules.Categories.Handlers;

public static class GetAll
{
    public static async Task<IResult> Handle(ICategoryService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);

        if(entites is null)
            return Results.NotFound(ErrorMessage<Category>.ItemsNotFound());

        var categories = new List<Category>();
        categories.AddRange(entites.Select(c => new Category { Id = c.Id, Name = c.Name }));
        return Results.Ok(categories);
    }
}
