using CookTo.Shared.Features.ManageBookmarks.AddBookmarks;

namespace CookTo.Shared.Features.ManageBookmarks.Validators;

public class AddBookmarksRequestValidator : AbstractValidator<AddBookmarksRequest>
{
    public AddBookmarksRequestValidator() { RuleFor(x => x.bookmarks).SetValidator(new BookmarksValidator()); }
}