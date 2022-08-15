﻿using Bogus;
using CookTo.Server.Modules.Categories.Core;

namespace CookTo.Tests.Fakes;

public class CategoryDocumentFaker : Faker<CategoryDocument>
{
    public CategoryDocumentFaker()
    {
        RuleFor(o => o.Id, f => f.Random.Guid().ToString());
        RuleFor(o => o.Text, f => f.Random.Word());
    }
}
