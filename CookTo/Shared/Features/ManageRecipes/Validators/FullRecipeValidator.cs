namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class FullRecipeValidator : AbstractValidator<FullRecipe>
{
    public FullRecipeValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Please provide a title for this recipe");
        RuleFor(x => x.Title).MinimumLength(5).WithMessage("Please provide a title longer than 5 charcters");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Please select a category");

        //  RuleFor(x => x.Description).NotEmpty().WithMessage("Please provide a description of the recipe");
        RuleFor(x => x.Description)
            .MinimumLength(40)
            .WithMessage("Please provide a description longer than 40 characters");
      

        RuleFor(x => x.Serves).GreaterThan(0).WithMessage("Please provide the number of servings ");

        RuleFor(x => x.CookTime).GreaterThan(0).WithMessage("Please provide approx cook time ");

        RuleFor(x => x.PrepTime).GreaterThan(0).WithMessage("Please provide approx prep time ");

        RuleFor(x => x.CookingSteps).NotEmpty().WithMessage("Please provide at least 1 cooking step");
      

      
        RuleForEach(x => x.CookingSteps).SetValidator(new CookingStepValidator());
        RuleForEach(x => x.Utensils).SetValidator(new UtensilPartValidator());
    }
}