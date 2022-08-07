using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Shared.Modules;

public record HighlightedRecipe
(
   string Id,
   Category Category,
   string Title,
   Cuisine Cuisine,
   string Image,
   string Creator,
   string AddedBy,
   int PrepTime,
   int CookTime,
   string Description,
   List<Dietary> Dietaries,
   List<string> ShoppingList,
  string Tags
);
