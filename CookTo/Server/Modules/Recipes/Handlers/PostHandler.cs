
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared.Modules.ManageRecipes;
using Newtonsoft.Json.Linq;


namespace CookTo.Server.Modules.Recipes.Handlers;

public static class PostHandler
{
    public static async Task<IResult> Handle(Recipe recipe, CommonParameters cp)
    {
        var entity = RecipeToRecipeDocumentConverter.Convert(recipe);
        await cp.RecipeService.CreateAsync(entity, cp.CancellationToken);


        return Results.Created($"/api/recipe/{entity.Id}", entity);
    }
}

