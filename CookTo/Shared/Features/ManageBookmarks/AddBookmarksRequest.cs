using MediatR;

namespace CookTo.Shared.Features.ManageBookmarks;

public record AddBookmarksRequest(BookmarksDto bookmarks) : IRequest<AddBookmarksRequest.Response>
{
    public const string RouteTemplate = "api/Bookmarks";
    public record Response(BookmarksDto Bookmarks);
}
