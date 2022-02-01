﻿using CookTo.Shared.Features.ManageBookmarks.Shared;

namespace CookTo.Shared.Features.ManageBookmarks.Validators;

public class BookMarkedValidator : AbstractValidator<BookMarked>
{
    public BookMarkedValidator()
    {
        RuleFor(x => x.BookMarkedRecipeId).NotEmpty().WithMessage("The recipe Id is required");
        RuleFor(x => x.RecipeTitle).NotEmpty().WithMessage("The recipe title is required");
    }
}