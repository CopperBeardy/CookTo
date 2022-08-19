using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Categories.Handlers;

public static class GetAll
{
    public static async Task<List<Category>> Handle(ICategoryService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);
        var categories = new List<Category>();

        if(entites is not null || entites.Any())
            categories.AddRange(entites.Select(c => new Category { Id = c.Id, Name = c.Name }));

        return categories;
    }
}
