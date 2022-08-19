using Bogus;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Tests.Fakes;

public class CategoryFaker : Faker<Category>
{
    public CategoryFaker()
    {
        RuleSet("New", set =>
        {
            set.RuleFor(o => o.Name, f => f.Random.Word());
        });
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}
