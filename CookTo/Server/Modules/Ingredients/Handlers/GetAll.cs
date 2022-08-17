using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageIngredients;


namespace CookTo.Server.Modules.Ingredients.Handlers;

public static class GetAll
{
    public static async Task<IResult> Handle(IIngredientService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);

        if(entites is null)
            return Results.NotFound(ErrorMessage<IngredientDocument>.ItemsNotFound());

        var ingredient = new List<Ingredient>();
        ingredient.AddRange(entites.Select(c => new Ingredient { Id = c.Id, Name = c.Name }));
        return Results.Ok(ingredient);
    }
}
