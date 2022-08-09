using CookTo.Server.Modules.Categories.Services;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using MediatR;


namespace CookTo.Server.Modules.Cuisines.Handlers;

public static class GetAllHandler
{
    public static async Task<IResult> Handle(CommonParameters cp)
    {
        var entites = await cp.CuisineService.GetAllAsync(cp.CancellationToken);

        if(entites is null)
            return Results.NotFound(ErrorMessage<CuisineDocument>.ItemsNotFound());

        var cuisines = new List<Cuisine>();
        cuisines.AddRange(entites.Select(c => new Cuisine { Id = c.Id, Text = c.Text }));
        return Results.Ok(cuisines);
    }
}
