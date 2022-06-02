using CookTo.Server.Documents;
using Microsoft.Extensions.Options;

namespace CookTo.Server.DbContext;

public class CookToDbContext : ICookToDbContext
{
    private readonly IMongoDatabase db;
    private readonly MongoClient client;

    public IClientSessionHandle? Session { get; set; }

    public CookToDbContext(IOptions<MongoSettings> configuration)
    {
        client = new MongoClient(configuration.Value.Connection);
        db = client.GetDatabase(configuration.Value.Database);
        Seed();
    }

    public IMongoCollection<T> GetCollection<T>(string name) => db.GetCollection<T>(name);

    private void Seed()
    {
        if (!client.ListDatabaseNames().Any())
        {
            SeedIngredientCollection();
            SeedCuisineCollection();
            SeedCategoryCollection();
            SeedUtensilCollection();
        }
    }

    private async void SeedIngredientCollection()
    {
        var ingredients = new List<IngredientDocument>()
        {
            new IngredientDocument() { Name = "Strong White Bread Flour" },
            new IngredientDocument() { Name = "Lemon" },
            new IngredientDocument() { Name = "Fast Acting Yeast" },
            new IngredientDocument() { Name = "Caster Sugar" }
        };

        var collection = db.GetCollection<IngredientDocument>(nameof(IngredientDocument));
        await collection.InsertManyAsync(ingredients);
    }

    private async void SeedCuisineCollection()
    {
        var cuisines = new List<CuisineDocument>()
        {
            new CuisineDocument() { Name = "British" },
            new CuisineDocument() { Name = "French" },
            new CuisineDocument() { Name = "Chinese" },
            new CuisineDocument() { Name = "Italian" }
        };

        var collection = db.GetCollection<CuisineDocument>(nameof(CuisineDocument));
        await collection.InsertManyAsync(cuisines);
    }

    private async void SeedCategoryCollection()
    {
        var categories = new List<CategoryDocument>()
        {
            new CategoryDocument() { Name = "Cake" },
            new CategoryDocument() { Name = "Baking" },
            new CategoryDocument() { Name = "Main" },
            new CategoryDocument() { Name = "Light Meal" },
            new CategoryDocument() { Name = "Starter" },
            new CategoryDocument() { Name = "Nibbles" },
            new CategoryDocument() { Name = "Brunch" },
            new CategoryDocument() { Name = "Side" },
            new CategoryDocument() { Name = "Dessert" }
        };

        var collection = db.GetCollection<CategoryDocument>(nameof(CategoryDocument));
        await collection.InsertManyAsync(categories);
    }

    private async void SeedUtensilCollection()
    {
        var utensils = new List<UtensilDocument>()
        {
            new UtensilDocument() { UtensilName = "Muffin Moulds" },
            new UtensilDocument() { UtensilName = "20cm loose fitting Cake Tin" },
            new UtensilDocument() { UtensilName = "Whisk" },
            new UtensilDocument() { UtensilName = "Electric Whisk" },
        };

        var collection = db.GetCollection<UtensilDocument>(nameof(UtensilDocument));
        await collection.InsertManyAsync(utensils);
    }
}
