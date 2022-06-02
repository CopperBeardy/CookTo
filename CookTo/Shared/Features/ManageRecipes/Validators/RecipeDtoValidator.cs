
namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class RecipeDtoValidator : AbstractValidator<FullRecipe>
{
    public RecipeDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Please provide a title for this recipe");
        RuleFor(x => x.Title).MinimumLength(5).WithMessage("Please provide a title longer than 5 charcters");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Please select a category");

        //  RuleFor(x => x.Description).NotEmpty().WithMessage("Please provide a description of the recipe");
        RuleFor(x => x.Description)
            .MinimumLength(40)
            .WithMessage("Please provide a description longer than 40 characters");
        RuleFor(x => x.PrepTimeFrom).GreaterThan(0).WithMessage("Please provide the estimated minimum preparation time");
        RuleFor(x => x.PrepTimeTo)
            .GreaterThan(x => x.PrepTimeFrom)
            .WithMessage("Estimate maximum preperation time needs to be be greater than the estimated minimum");
        RuleFor(x => x.CookTimeFrom).GreaterThan(0).WithMessage("Please provide the estimated minimum cooking time");
        RuleFor(x => x.CookTimeTo)
            .GreaterThan(x => x.CookTimeFrom)
            .WithMessage("Estimate maximum cooking time needs to be be greater than the estimated minimum");

        RuleFor(x => x.Serves).GreaterThan(0).WithMessage("Please provide the number of servings ");
        RuleFor(x => x.RecipeParts).NotEmpty().WithMessage("Please provide at least 1 part section ");
        RuleFor(x => x.RecipeParts)
            .NotEmpty()
            .WithMessage("Please provide at least 1 Utensil required for making this recipe ");
  
        RuleForEach(x => x.RecipeParts).SetValidator(new RecipePartValidator());
        RuleForEach(x => x.Utensils).SetValidator(new UtensilPartValidator());
    }
}