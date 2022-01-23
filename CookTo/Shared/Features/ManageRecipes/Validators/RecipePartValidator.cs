namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class RecipePartValidator : AbstractValidator<RecipeDto.RecipePart>
{
    public RecipePartValidator()
    {
        RuleFor(x => x.PartTitle).NotEmpty().WithMessage("Please supply a title for this recipe part");
        RuleFor(x => x.PartTitle).MinimumLength(5).WithMessage("Please make the title atleast 5 characters long");
        RuleFor(x => x.Items).NotEmpty().WithMessage("Please supply atleast 1 ingredient part");
        RuleForEach(x => x.Items).SetValidator(new PartIngredientValidator());
    }
}
