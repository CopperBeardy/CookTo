using Bogus;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Tests.Fakes;

public class UtensilFaker : Faker<Utensil>
{
    public UtensilFaker() { RuleFor(o => o.Text, f => f.Random.Word()); }
}
