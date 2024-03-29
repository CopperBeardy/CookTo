﻿using Bogus;
using CookTo.Shared.Models.ManageRecipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Tests.Fakes;

public  class RecipePartFaker : Faker<RecipePart>
{
	public RecipePartFaker()
	{
		RuleSet("WithTitle", set =>
		{
			set.RuleFor(x => x.Title, f => f.Random.Word());
			set.RuleFor(x => x.RecipePartIngredients, new PartIngredientFaker().GenerateBetween(1, 5));
		});
		RuleFor(x => x.Title, string.Empty);
		RuleFor(x => x.RecipePartIngredients, new PartIngredientFaker().GenerateBetween(1, 5));
	}
}
