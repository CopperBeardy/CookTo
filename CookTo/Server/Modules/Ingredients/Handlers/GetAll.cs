using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageIngredients;


namespace CookTo.Server.Modules.Ingredients.Handlers;

public static class GetAll
{
    public static async Task<List<Ingredient>?> Handle(IIngredientService service, CancellationToken cancellationToken)
    {
        var entites = await service.GetAllAsync(cancellationToken);

        var ingredients = new List<Ingredient>();

        if(entites is not null || entites.Any())
            ingredients.AddRange(entites.Select(c => new Ingredient { Id = c.Id, Name = c.Name }));

        return ingredients;
    }
}
