namespace CookTo.Shared.Modules.ManageRecipes.Validators;

public class CookingStepValidator : AbstractValidator<CookingStep>
{
    public CookingStepValidator()
    {
        RuleFor(x => x.OrderNumber).NotEmpty().WithMessage("Please supply the positon number for this step");
        //RuleFor(x => x.StepDescription).NotEmpty().WithMessage("Please supply the description of this step");
        RuleFor(x => x.StepDescription).MinimumLength(10).WithMessage("Description needs to be more than 10 characters");

        //RuleFor(x => x.CookingSteps).NotEmpty().WithMessage("Please provide at least 1 cooking direction ");
        //RuleForEach(x => x.CookingSteps).SetValidator(new CookingStepValidator());
    }
}
