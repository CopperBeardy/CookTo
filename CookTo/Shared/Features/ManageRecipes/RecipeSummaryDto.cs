using CookTo.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    string ImageFileName,
    string Author
);
