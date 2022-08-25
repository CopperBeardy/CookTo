using Bogus;
using CookTo.DataAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;

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
        RuleFor(o => o.Creator, f => f.Random.Word().ToString());
        RuleFor(o => o.AddedBy, f => f.Random.Word().ToString());
        RuleFor(o => o.Dietaries, SharedGenerators.GenerateDietaries());
        RuleFor(o => o.CookingSteps, new CookingStepDocumentFaker().GenerateBetween(1, 5));
        RuleFor(o => o.Utensils, new UtensilPartDocumentFaker().GenerateBetween(1, 4));
        RuleFor(o => o.Tips, new TipDocumentFaker().GenerateBetween(0, 2));
        RuleFor(o => o.ShoppingItems, new ShoppingItemDocumentFaker().GenerateBetween(0, 6));
        RuleFor(o => o.ShoppingList, SharedGenerators.GenerateShoppingList());
        RuleFor(o => o.Tags, f => f.Lorem.Sentence());
    }
}
