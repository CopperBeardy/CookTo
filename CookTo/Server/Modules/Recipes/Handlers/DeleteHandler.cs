namespace CookTo.Server.Modules.Recipes.Handlers;

public static class DeleteHandler
{
    public static async Task<IResult> Handle(string id, CommonParameters cp)
    {
        var recipe = await cp.RecipeService.GetByIdAsync(id, cp.CancellationToken);
        if (recipe is null)
        {
            return Results.NotFound();
        }
        await cp.RecipeService.DeleteAsync(id, cp.CancellationToken);


        return Results.NoContent();
    }
}
