﻿using CookTo.Shared.Features.ManageIngredients.AddIngredient;

namespace CookTo.Shared.Features.ManageIngredients.Validators;

public class AddIngredientRequestValidator : AbstractValidator<AddIngredientRequest>
{
    public AddIngredientRequestValidator() { RuleFor(x => x.ingredient).SetValidator(new IngredientDtoValidator()); }
}