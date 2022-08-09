using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Categories.Services;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Cuisines.Handlers;

public static class PostHandler
{
    public static async Task<IResult> Handle(Cuisine cuisine, CommonParameters common)
    {
        var newCuisine = new CuisineDocument() { Text = cuisine.Text };
        await common.CuisineService.CreateAsync(newCuisine, common.CancellationToken);
        return Results.Ok(new Cuisine { Id = newCuisine.Id, Text = newCuisine.Text });
    }
}

