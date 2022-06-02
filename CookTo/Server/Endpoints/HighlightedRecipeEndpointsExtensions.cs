using AutoMapper;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Server.Endpoints;

public static class HighlightedEndpointsExtensions
{
    public static void HighlightedRecipeEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/highlighted",
            async (IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                //Todo: this is a code smell
                // the hightlight recipe will be set by admin when fully implemented
                // admin area not ready so taking the first recipe all the time

                var recipes = await service.GetAllAsync(token);
                var recipe = recipes.FirstOrDefault();
                //    var recipe = await service.GetByIdAsync("622224f121307568e8720d59", token);

                return Results.Ok(mapper.Map<HighlightedRecipe>(recipe));
            });
    }
}
