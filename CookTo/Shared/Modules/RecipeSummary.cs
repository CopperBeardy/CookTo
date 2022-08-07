using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;


namespace CookTo.Shared.Modules;

public record RecipeSummary
(
     string Id,
     Category Category,
     string Title,
     Cuisine Cuisine,
     string Image,
     string Creator,
     string AddedBy,
     List<Dietary>? Dietary,
     List<string> ShoppingList,
     string Tags
);