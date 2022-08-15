using Bogus;
using CookTo.Shared.Modules.ManageCategories;

namespace CookTo.Tests.Fakes;

public class CategoryFaker : Faker<Category>
{
    public CategoryFaker() { RuleFor(o => o.Text, f => f.Random.Word()); }
}
