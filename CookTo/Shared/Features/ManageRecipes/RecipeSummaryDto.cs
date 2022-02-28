using CookTo.Shared.Enums;
using CookTo.Shared.Features.ManageCuisine;

namespace CookTo.Shared.Features.ManageRecipes;

public record RecipeSummaryDto
(
    string RecipeId,
    Category Category,
    string RecipeTitle,
    int PrepTimeFrom,
    int PrepTimeTo,
    int CookTimeFrom,
    int CookTimeTo,
    CuisineDto Cuisine,
    string ImageFileName,
    string Author
);
