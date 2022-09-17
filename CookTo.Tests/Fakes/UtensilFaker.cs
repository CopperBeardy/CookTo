using Bogus;
using CookTo.Shared.Models.ManageUtensils;

namespace CookTo.Tests.Fakes;

public class UtensilFaker : Faker<Utensil>
{
    public UtensilFaker()
    {
        RuleSet("New", set =>
        {
            set.RuleFor(o => o.Name, f => f.Random.Word());
        });
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}
