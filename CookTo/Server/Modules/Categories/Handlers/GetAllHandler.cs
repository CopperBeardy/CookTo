using CookTo.Server.Modules.Categories.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;
using MediatR;


namespace CookTo.Server.Modules.Categories.Handlers;

public static class GetAllHandler
{
    public static async Task<IResult> Handle(CommonParameters cp)
    {
        var entites = await cp.CategoryService.GetAllAsync(cp.CancellationToken);

        if(entites is null)
            return Results.NotFound(ErrorMessage<Category>.ItemsNotFound());

        var categories = new List<Category>();
        categories.AddRange(entites.Select(c => new Category { Id = c.Id, Text = c.Text }));
        return Results.Ok(categories);
    }
}
