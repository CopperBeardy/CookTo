using FluentValidation;

namespace CookTo.Shared.Models.ManageRecipes.Validators;

public class RecipeValidator : AbstractValidator<Recipe>
{
    public RecipeValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Please provide a title for this recipe");
        RuleFor(x => x.Title).MinimumLength(5).WithMessage("Please provide a title longer than 5 charcters");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Please select a category");

        //  RuleFor(x => x.Description).NotEmpty().WithMessage("Please provide a description of the recipe");
        RuleFor(x => x.Description)
            .MinimumLength(40)
            .WithMessage("Please provide a description longer than 40 characters");


        RuleFor(x => x.Serves).NotEmpty().WithMessage("Please provide the number of servings or quatnity made ");

        RuleFor(x => x.CookTime).GreaterThan(0).WithMessage("Please provide approx cook time ");

        RuleFor(x => x.PrepTime).GreaterThan(0).WithMessage("Please provide approx prep time ");

        RuleFor(x => x.CookingSteps).NotEmpty().WithMessage("Please provide at least 1 cooking step");


        RuleForEach(x => x.CookingSteps).SetValidator(new CookingStepValidator());

        RuleFor(x => x.RecipeParts).NotEmpty().WithMessage("Please provide at least 1 part with its ingredients");
        RuleForEach(x => x.RecipeParts).SetValidator(new RecipePartValidator());

        RuleForEach(x => x.Utensils).SetValidator(new UtensilPartValidator());
        RuleFor(x => x.ShoppingItems).NotEmpty().WithMessage("Please provide items needed for this recipe");
        RuleForEach(x => x.ShoppingItems).SetValidator(new ShoppingItemValidator());
    }
}