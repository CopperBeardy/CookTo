using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Shared.Modules.ManageRecipes;

public record RecipeSummary
(
    string RecipeId,
    Category Category,
    string RecipeTitle,
    Cuisine Cuisine,
    string ImageFileName,
    string Creator,
    string AddedBy
);
