﻿using Bogus;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Tests.Fakes;

public class UtensilFaker : Faker<Utensil>
{
    public UtensilFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}