using CookTo.Server.Modules.Categories.Core;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Server.Modules.Categories.Handlers;

public static class PostHandler
{
    public static async Task<IResult> Handle(Category category, CommonParameters cp)
    {
        var newCategory = new CategoryDocument() { Text = category.Text };
        await cp.CategoryService.CreateAsync(newCategory, cp.CancellationToken);
        return Results.Ok(new Category { Id = newCategory.Id, Text = newCategory.Text });
    }
}

