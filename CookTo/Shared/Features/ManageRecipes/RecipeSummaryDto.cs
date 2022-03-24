using CookTo.Shared.Features.ManageCategory;
using CookTo.Shared.Features.ManageCuisine;

namespace CookTo.Shared.Features.ManageRecipes;

public record RecipeSummaryDto
(
    string RecipeId,
    CategoryDto Category,
    string RecipeTitle,
    CuisineDto Cuisine,
    string ImageFileName,
    string Creator,
    string AddedBy
);
