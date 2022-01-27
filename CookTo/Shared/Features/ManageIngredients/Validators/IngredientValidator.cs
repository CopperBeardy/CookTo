namespace CookTo.Shared.Features.ManageIngredients.Validators;

public class IngredientValidator : AbstractValidator<IngredientResultDto>
{
    public IngredientValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please provide the name of this ingredient");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Please provide a name longer than 2 characters");
    }
}