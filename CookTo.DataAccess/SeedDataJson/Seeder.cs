using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.DataAccess.SeedDataJson;

public static class Seeder
{
    public static void HasSeeded(IMongoDatabase db)
    {
        if(!db.ListCollections().Any())
        {
            Seed(db);
        }
    }

    public static void Seed(IMongoDatabase db)
    {
        var result = db.ListCollections().Any();
        if(!result)
        {
            SeedIngredientCollection(db);
            SeedCuisineCollection(db);
            SeedCategoryCollection(db);
            SeedUtensilCollection(db);
        }
    }

    private static  void SeedIngredientCollection(IMongoDatabase db)
    {
        var collection = db.GetCollection<IngredientDocument>(nameof(IngredientDocument));


        var ingredients = new List<IngredientDocument>()
        {
            new IngredientDocument() { Name = "Strong White Bread Flour" },
            new IngredientDocument() { Name = "Lemon" },
            new IngredientDocument() { Name = "Fast Acting Yeast" },
            new IngredientDocument() { Name = "Caster Sugar" } };

        collection.InsertMany(ingredients);
    }

    private static  void SeedCuisineCollection(IMongoDatabase db)
    {
        var cuisines = new List<CuisineDocument>()
        {
            new CuisineDocument() { Name = "British" },
            new CuisineDocument() { Name = "French" },
            new CuisineDocument() { Name = "Chinese" },
            new CuisineDocument() { Name = "Italian" } };

        var collection = db.GetCollection<CuisineDocument>(nameof(CuisineDocument));
        collection.InsertMany(cuisines);
    }

    private static  void SeedCategoryCollection(IMongoDatabase db)
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
            new CategoryDocument() { Name = "Dessert" } };

        var collection = db.GetCollection<CategoryDocument>(nameof(CategoryDocument));
        collection.InsertMany(categories);
    }

    private static void SeedUtensilCollection(IMongoDatabase db)
    {
        var utensils = new List<UtensilDocument>()
        {
            new UtensilDocument() { Name = "Muffin Moulds" },
            new UtensilDocument() { Name = "20cm loose fitting Cake Tin" },
            new UtensilDocument() { Name = "Whisk" },
            new UtensilDocument() { Name = "Electric Whisk" },
        };

        var collection = db.GetCollection<UtensilDocument>(nameof(UtensilDocument));
        collection.InsertMany(utensils);
    }
}
