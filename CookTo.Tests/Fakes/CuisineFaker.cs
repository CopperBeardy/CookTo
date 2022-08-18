﻿using Bogus;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Tests.Fakes;

public class CuisineFaker : Faker<Cuisine>
{
    public CuisineFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Name, f => f.Random.Word());
    }
}