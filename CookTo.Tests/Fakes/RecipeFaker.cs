using Bogus;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class RecipeFaker : Faker<Recipe>
{
    public RecipeFaker()
    {
        RuleSet("New", set =>
        {
            set.RuleFor(o => o.Title, f => f.Random.Word());
            set.RuleFor(o => o.Cuisine, new CuisineFaker().Generate());
            set.RuleFor(o => o.Category, new CategoryFaker().Generate());
            set.RuleFor(o => o.Description, f => f.Lorem.Paragraph());
            set.RuleFor(o => o.Image, f => f.Random.Word());
            set.RuleFor(o => o.PrepTime, f => f.Random.Number());
            set.RuleFor(o => o.CookTime, f => f.Random.Number());
            set.RuleFor(o => o.Serves, f => f.Random.Number().ToString());
            set.RuleFor(o => o.Creator, f => f.Random.Word().ToString());
            set.RuleFor(o => o.AddedBy, f => f.Random.Word().ToString());
            set.RuleFor(o => o.Dietaries, SharedGenerators.GenerateDietaries());
            set.RuleFor(o => o.CookingSteps, new CookingStepFaker().GenerateBetween(1, 5));
            set.RuleFor(o => o.Utensils, new UtensilPartFaker().GenerateBetween(1, 4));
            set.RuleFor(o => o.Tips, new TipFaker().GenerateBetween(0, 2));
            set.RuleFor(o => o.ShoppingItems, new ShoppingItemFaker().GenerateBetween(1, 6));
            set.RuleFor(o => o.ShoppingList, SharedGenerators.GenerateShoppingList());
            set.RuleFor(o => o.Tags, f => f.Lorem.Sentence());
        });

        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Title, f => f.Random.Word());
        RuleFor(o => o.Cuisine, new CuisineFaker().Generate());
        RuleFor(o => o.Category, new CategoryFaker().Generate());
        RuleFor(o => o.Description, f => f.Lorem.Paragraph());
        RuleFor(o => o.Image, f => f.Random.Word());
        RuleFor(o => o.PrepTime, f => f.Random.Number());
        RuleFor(o => o.CookTime, f => f.Random.Number());
        RuleFor(o => o.Serves, f => f.Random.Number().ToString());
        RuleFor(o => o.Creator, f => f.Random.Word().ToString());
        RuleFor(o => o.AddedBy, f => f.Random.Word().ToString());
        RuleFor(o => o.Dietaries, SharedGenerators.GenerateDietaries());
        RuleFor(o => o.CookingSteps, new CookingStepFaker().GenerateBetween(1, 5));
        RuleFor(o => o.Utensils, new UtensilPartFaker().GenerateBetween(1, 4));
        RuleFor(o => o.Tips, new TipFaker().GenerateBetween(0, 2));
        RuleFor(o => o.ShoppingItems, new ShoppingItemFaker().GenerateBetween(1, 6));
        RuleFor(o => o.ShoppingList, SharedGenerators.GenerateShoppingList());
        RuleFor(o => o.Tags, f => f.Lorem.Sentence());
    }
}
