﻿using CookTo.Shared.Features.ManageRecipes.Shared;

namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class PartIngredientValidator : AbstractValidator<PartIngredient>
{
    public PartIngredientValidator()
    {
        RuleFor(x => x.Amount).NotEmpty().WithMessage("Please provide the required amount");
        RuleFor(x => x.Unit).NotEmpty().WithMessage("Please select the appropritate measurement unit");
        RuleFor(x => x.IngredientName).NotEmpty().WithMessage("Please select a ingredient");
    }
}