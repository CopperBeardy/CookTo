using Bogus;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Tests.Fakes;

public class CategoryFaker : Faker<Category>
{
    public CategoryFaker() { RuleFor(o => o.Name, f => f.Random.Word()); }
}
