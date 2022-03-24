using CookTo.Server.Documents.CategoryDocument;
using CookTo.Server.Documents.CuisineDocument;
using CookTo.Server.Documents.IngredientDocument;
using CookTo.Server.Documents.UtensilDocument;
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
        var ingredients = new List<Ingredient>()
        {
            new Ingredient() { Name = "Strong White Bread Flour" },
            new Ingredient() { Name = "Lemon" },
            new Ingredient() { Name = "Fast Acting Yeast" },
            new Ingredient() { Name = "Caster Sugar" }
        };

        var collection = db.GetCollection<Ingredient>(nameof(Ingredient));
        await collection.InsertManyAsync(ingredients);
    }

    private async void SeedCuisineCollection()
    {
        var cuisines = new List<Cuisine>()
        {
            new Cuisine() { Name = "British" },
            new Cuisine() { Name = "French" },
            new Cuisine() { Name = "Chinese" },
            new Cuisine() { Name = "Italian" }
        };

        var collection = db.GetCollection<Cuisine>(nameof(Cuisine));
        await collection.InsertManyAsync(cuisines);
    }

    private async void SeedCategoryCollection()
    {
        var categories = new List<Category>()
        {
            new Category() { Name = "Cake" },
            new Category() { Name = "Baking" },
            new Category() { Name = "Main" },
            new Category() { Name = "Light Meal" },
            new Category() { Name = "Starter" },
            new Category() { Name = "Nibbles" },
            new Category() { Name = "Brunch" },
            new Category() { Name = "Side" },
            new Category() { Name = "Dessert" }
        };

        var collection = db.GetCollection<Category>(nameof(Category));
        await collection.InsertManyAsync(categories);
    }

    private async void SeedUtensilCollection()
    {
        var utensils = new List<Utensil>()
        {
            new Utensil() { UtensilName = "Muffin Moulds" },
            new Utensil() { UtensilName = "20cm loose fitting Cake Tin" },
            new Utensil() { UtensilName = "Whisk" },
            new Utensil() { UtensilName = "Electric Whisk" },
        };

        var collection = db.GetCollection<Utensil>(nameof(Utensil));
        await collection.InsertManyAsync(utensils);
    }
}
