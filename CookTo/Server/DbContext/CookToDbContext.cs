using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Server.Modules.Utensils.Core;
using Microsoft.Extensions.Options;

namespace CookTo.Server.DbContext;

public class CookToDbContext : ICookToDbContext
{
    private readonly IMongoDatabase db;
    private readonly MongoClient client;

    public IClientSessionHandle? Session { get; set; }

    public CookToDbContext(IOptions<MongoSettings> configuration)
    {
        //client = new MongoClient(configuration.Value.Connection);
        //db = client.GetDatabase(configuration.Value.Database);
        client = new MongoClient(configuration.Value.Connection);

        db = client.GetDatabase(configuration.Value.Database);
        Seed();
    }

    public IMongoCollection<T> GetCollection<T>(string name) => db.GetCollection<T>(name);

    private void Seed()
    {
        var result = db.ListCollections().Any();
        if (!result)
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
            new IngredientDocument() { Text = "Strong White Bread Flour" },
            new IngredientDocument() { Text = "Lemon" },
            new IngredientDocument() { Text = "Fast Acting Yeast" },
            new IngredientDocument() { Text = "Caster Sugar" } };

        var collection = db.GetCollection<IngredientDocument>(nameof(IngredientDocument));
        await collection.InsertManyAsync(ingredients);
    }

    private async void SeedCuisineCollection()
    {
        var cuisines = new List<CuisineDocument>()
        {
            new CuisineDocument() { Text = "British" },
            new CuisineDocument() { Text = "French" },
            new CuisineDocument() { Text = "Chinese" },
            new CuisineDocument() { Text = "Italian" } };

        var collection = db.GetCollection<CuisineDocument>(nameof(CuisineDocument));
        await collection.InsertManyAsync(cuisines);
    }

    private async void SeedCategoryCollection()
    {
        var categories = new List<CategoryDocument>()
        {
            new CategoryDocument() { Text = "Cake" },
            new CategoryDocument() { Text = "Baking" },
            new CategoryDocument() { Text = "Main" },
            new CategoryDocument() { Text = "Light Meal" },
            new CategoryDocument() { Text = "Starter" },
            new CategoryDocument() { Text = "Nibbles" },
            new CategoryDocument() { Text = "Brunch" },
            new CategoryDocument() { Text = "Side" },
            new CategoryDocument() { Text = "Dessert" } };

        var collection = db.GetCollection<CategoryDocument>(nameof(CategoryDocument));
        await collection.InsertManyAsync(categories);
    }

    private async void SeedUtensilCollection()
    {
        var utensils = new List<UtensilDocument>()
        {
            new UtensilDocument() { Text = "Muffin Moulds" },
            new UtensilDocument() { Text = "20cm loose fitting Cake Tin" },
            new UtensilDocument() { Text = "Whisk" },
            new UtensilDocument() { Text = "Electric Whisk" },
        };

        var collection = db.GetCollection<UtensilDocument>(nameof(UtensilDocument));
        await collection.InsertManyAsync(utensils);
    }
}
