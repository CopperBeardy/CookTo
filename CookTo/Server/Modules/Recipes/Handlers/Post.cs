﻿using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared.Modules.ManageRecipes;


namespace CookTo.Server.Modules.Recipes.Handlers;

public static class Post
{
    public static async Task<Recipe> Handle(Recipe recipe, IRecipeService service, CancellationToken cancellationToken)
    {
        var entity = RecipeToRecipeDocumentConverter.Convert(recipe);
        await service.CreateAsync(entity, cancellationToken);

        return RecipeDocumentToRecipeConverter.Convert(entity);
    }
}

