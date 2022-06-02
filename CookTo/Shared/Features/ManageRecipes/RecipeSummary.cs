using CookTo.Shared.Models;

namespace CookTo.Shared.Features.ManageRecipes;

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
