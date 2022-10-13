using FluentValidation;
using System;
using System.Linq;

namespace CookTo.Shared.Models.ManageRecipes.Validators;

public sealed class RecipePartValidator : AbstractValidator<RecipePart>
{
	public RecipePartValidator()
	{
		RuleFor(x => x.RecipePartIngredients)
			.NotEmpty()
			.WithMessage("Please supply atleast one ingredient for this part");
		RuleForEach(x => x.RecipePartIngredients).SetValidator(new PartIngredientValidator());
	}
}
