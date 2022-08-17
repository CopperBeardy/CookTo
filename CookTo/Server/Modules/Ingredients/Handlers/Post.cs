using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Ingredients.Handlers;

public static class Post
{
    public static async Task<IResult> Handle(Ingredient ingredient, IIngredientService service, CancellationToken cancellationToken)
    {
        var newIngredient = new IngredientDocument() { Name = ingredient.Name };
        await service.CreateAsync(newIngredient, cancellationToken);
        return Results.Ok(new Ingredient { Id = newIngredient.Id, Name = newIngredient.Name });
    }
}

