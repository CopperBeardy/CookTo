using System;
using System.Linq;

namespace CookTo.Shared.Modules.ManageRecipes.Validators;

public class RecipePartValidator : AbstractValidator<RecipePart>
{
	public RecipePartValidator()
	{
		RuleFor(x => x.PartIngredients).NotEmpty().WithMessage("Please supply atleast one ingredient for this part");
		RuleForEach(x => x.PartIngredients).SetValidator(new PartIngredientValidator());
	}
}
