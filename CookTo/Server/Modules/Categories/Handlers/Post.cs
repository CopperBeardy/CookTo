using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Shared.Modules.ManageCategories;
using System.Threading;

namespace CookTo.Server.Modules.Categories.Handlers;

public static class Post
{
    public static async Task<Category> Handle(Category category, ICategoryService service, CancellationToken cancellationToken)
    {
        var newCategory = new CategoryDocument() { Name = category.Name };
        await service.CreateAsync(newCategory, cancellationToken);

        return new Category { Id = newCategory.Id, Name = newCategory.Name };
    }
}

