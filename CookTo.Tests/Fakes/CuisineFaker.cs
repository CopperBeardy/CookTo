using Bogus;
using CookTo.Shared.Models.ManageCuisines;

namespace CookTo.Tests.Fakes;

public class CuisineFaker : Faker<Cuisine>
{
    public CuisineFaker()
    {
        RuleSet("New", set =>
        {
            set.RuleFor(o => o.Name, f => f.Random.Word());
        });
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}
