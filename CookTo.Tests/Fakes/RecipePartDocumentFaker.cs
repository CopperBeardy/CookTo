using Bogus;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Tests.Fakes;

public class RecipePartDocumentFaker : Faker<RecipePartDocument>
{
    public RecipePartDocumentFaker()
    {
        RuleSet("WithTitle", set =>
        {
            set.RuleFor(x => x.Title, f => f.Random.Word());
            set.RuleFor(x => x.RecipePartIngredients, new PartIngredientDocumentFaker().GenerateBetween(1, 5));
        });
        RuleFor(x => x.Title, string.Empty);
        RuleFor(x => x.RecipePartIngredients, new PartIngredientDocumentFaker().GenerateBetween(1, 5));
    }
}

