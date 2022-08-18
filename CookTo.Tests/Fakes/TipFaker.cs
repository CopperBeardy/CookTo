using Bogus;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Tests.Fakes;

public class TipFaker : Faker<Tip>
{
    public TipFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Description, f => f.Lorem.Sentence());
    }
}
