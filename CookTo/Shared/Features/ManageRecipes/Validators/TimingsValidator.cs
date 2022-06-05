
namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class TimingsValidator : AbstractValidator<Timings>
{
    public TimingsValidator()
    {
        RuleFor(x => x.PrepTimeFrom).GreaterThan(0).WithMessage("Please provide the estimated minimum preparation time");
        RuleFor(x => x.PrepTimeTo)
            .GreaterThan(x => x.PrepTimeFrom)
            .WithMessage("Estimate maximum preperation time needs to be be greater than the estimated minimum");
        RuleFor(x => x.CookTimeFrom).GreaterThan(0).WithMessage("Please provide the estimated minimum cooking time");
        RuleFor(x => x.CookTimeTo)
            .GreaterThan(x => x.CookTimeFrom)
            .WithMessage("Estimate maximum cooking time needs to be be greater than the estimated minimum");
    }
}
