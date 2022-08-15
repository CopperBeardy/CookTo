using Bogus;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Shared.Enums;
using System;
using System.Collections.Generic;

namespace CookTo.Tests.Fakes;

public class RecipeDocumentFaker : Faker<RecipeDocument>
{
    public RecipeDocumentFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Title, f => f.Random.Word());
        RuleFor(o => o.Cuisine, new CuisineDocumentFaker().Generate());
        RuleFor(o => o.Category, new CategoryDocumentFaker().Generate());
        RuleFor(o => o.Description, f => f.Lorem.Paragraph());
        RuleFor(o => o.Image, f => f.Random.Word());
        RuleFor(o => o.PrepTime, f => f.Random.Number());
        RuleFor(o => o.CookTime, f => f.Random.Number());
        RuleFor(o => o.Serves, f => f.Random.Number().ToString());
        RuleFor(o => o.Dietaries, GenerateDietaries());
        RuleFor(o => o.CookingSteps, new CookingStepDocumentFaker().GenerateBetween(1, 5));
        RuleFor(o => o.Utensils, new UtensilPartDocumentFaker().GenerateBetween(1, 4));
        RuleFor(o => o.Tips, new TipFaker().GenerateBetween(0, 2));
        RuleFor(o => o.ShoppingItems, new ShoppingItemDocumentFaker().GenerateBetween(0, 6));
        RuleFor(o => o.ShoppingList, new Faker<string>().GenerateBetween(0, 6));
        RuleFor(o => o.Tags, f => f.Lorem.Sentence());
    }

    public static List<Dietary> GenerateDietaries()
    {
        var count = new Random().Next(0, 3);

        var dietaries = new List<Dietary>();
        if (count != 0)
        {
            for (int i = 0; i < count; i++)
            {
                dietaries.Add(new Faker().PickRandom<Dietary>());
            }
        }
        return dietaries;
    }
}
