﻿using CookTo.Server.Modules.Recipes.Services;

namespace CookTo.Server.Modules.Recipes.Handlers;


public record CommonParameters
{
    public IRecipeService RecipeService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}

