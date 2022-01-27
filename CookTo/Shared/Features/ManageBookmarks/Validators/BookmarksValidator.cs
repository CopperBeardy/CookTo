
namespace CookTo.Shared.Features.ManageBookmarks.Validators;

public class BookmarksValidator : AbstractValidator<AddBookmarksDto>
{
    public BookmarksValidator() { RuleFor(x => x.UserId).NotEmpty().WithMessage("Id of the current user is needed"); }
}