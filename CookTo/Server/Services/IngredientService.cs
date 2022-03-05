using CookTo.Server.Documents.IngredientDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class IngredientService : BaseService<Ingredient>, IIngredientService
{
    public IngredientService(ICookToDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Seed()
    {
        var ingredients = new List<Ingredient>()
        {
            new Ingredient() { Name = "Strong White Bread Flour" },
            new Ingredient() { Name = "Lemon" },
            new Ingredient() { Name = "Fast Acting Yeast" },
            new Ingredient() { Name = "Caster Sugar" }
        };

        await dbCollection.InsertManyAsync(ingredients);
    }
}