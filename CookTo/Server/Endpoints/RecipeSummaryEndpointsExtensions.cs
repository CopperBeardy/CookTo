using AutoMapper;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageCategory;
using CookTo.Shared.Features.ManageCuisine;
using CookTo.Shared.Features.ManageRecipes;


namespace CookTo.Server.Endpoints;

public static class RecipeSummaryEndpointsExtensions
{
    public static void RecipeSummaryEndpoints(this WebApplication app)
    {
        //todo this will be a curated list by a admin 
        //until implmented the first x amount is retrieved
        app.MapGet(
            "/api/recipes/{amount}",
            async (string amount, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipes = await service.GetByLimit(int.Parse(amount), token);
                List<RecipeSummaryDto> recipeSummaries = new List<RecipeSummaryDto>();
                foreach (var recipe in recipes)
                {
                    recipeSummaries.Add(
                        new RecipeSummaryDto(
                            recipe.Id,
                            mapper.Map<CategoryDto>(recipe.Category),
                            recipe.Title,
                            mapper.Map<CuisineDto>(recipe.Cuisine),
                            recipe.Image,
                            string.IsNullOrEmpty(recipe.Creator) ? string.Empty : recipe.Creator,
                            recipe.AddedBy));
                }
                return Results.Ok(recipeSummaries);
            });

        app.MapGet(
            "/api/searchrecipes/{term}",
            async (string term, IRecipeService service, IMapper mapper, CancellationToken token) =>
            {
                var recipes = await service.GetAllByTerm(term, token);
                List<RecipeSummaryDto> recipeSummaries = new List<RecipeSummaryDto>();
                foreach (var recipe in recipes)
                {
                    recipeSummaries.Add(
                        new RecipeSummaryDto(
                            recipe.Id,
                            mapper.Map<CategoryDto>(recipe.Category),
                            recipe.Title,
                            mapper.Map<CuisineDto>(recipe.Cuisine),
                            recipe.Image,
                            string.IsNullOrEmpty(recipe.Creator) ? string.Empty : recipe.Creator,
                            recipe.AddedBy));
                }
                return Results.Ok(recipeSummaries);
            });
    }
}
