
namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class AddRecipeDtoValidator : AbstractValidator<AddRecipeDto>
{
    public AddRecipeDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Please provide a title for this recipe");
        RuleFor(x => x.Title).MinimumLength(5).WithMessage("Please provide a title longer than 5 charcters");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Please select a catagory");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Please provide a description of the recipe");
        RuleFor(x => x.Description)
            .MinimumLength(40)
            .WithMessage("Please provide a description longer than 40 characters");
        RuleFor(x => x.PreparationTime).NotEmpty().WithMessage("Please provide the preparation time");
        RuleFor(x => x.CookingTime).NotEmpty().WithMessage("Please provide the cooking time");
        RuleFor(x => x.Serves).NotEmpty().WithMessage("Please provide the number of servings ");
        RuleFor(x => x.RecipeParts).NotEmpty().WithMessage("Please provide at least 1 part section ");
        RuleFor(x => x.RecipeParts)
            .NotEmpty()
            .WithMessage("Please provide at least 1 Utensil required for making this recipe ");
        RuleFor(x => x.CookingSteps).NotEmpty().WithMessage("Please provide at least 1 cooking direction ");
    }
}