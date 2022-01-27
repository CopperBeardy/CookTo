using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Shared.Features.ManageUtensils.Validators;

public  class AddUtensilsDtoValidator : AbstractValidator<AddUtensilDto>
{
    public AddUtensilsDtoValidator()
    {
        RuleFor(x => x.UtensilName).NotEmpty().WithMessage("Please select a Utensil");
        RuleFor(x => x.RequiredAmount).GreaterThan(0).WithMessage("Please enter a value of 1 or greater than ");
    }
}
