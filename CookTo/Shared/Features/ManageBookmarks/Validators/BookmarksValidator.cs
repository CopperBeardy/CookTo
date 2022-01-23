
namespace CookTo.Shared.Features.ManageBookmarks.Validators;

public class BookmarksValidator : AbstractValidator<BookmarksDto>
{
    public BookmarksValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Id of the current user is needed");
        RuleForEach(x => x.BookMarkedRecipes).SetValidator(new BookMarkedValidator());
    }
}