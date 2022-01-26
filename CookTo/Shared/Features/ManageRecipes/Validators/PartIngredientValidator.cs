﻿namespace CookTo.Shared.Features.ManageRecipes.Validators;

public class PartIngredientValidator : AbstractValidator<RecipeDto.RecipePart.PartIngredient>
{
    public PartIngredientValidator()
    {
        RuleFor(x => x.Amount).NotEmpty().WithMessage("Please provide the required amount");
        RuleFor(x => x.Unit).NotEmpty().WithMessage("Please select the appropritate measurement unit");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please provide the ingredient");
    }
}