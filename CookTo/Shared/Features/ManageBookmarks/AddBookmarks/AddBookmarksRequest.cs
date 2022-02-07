using CookTo.Shared.Features.ManageBookmarks.Shared;
using MediatR;

namespace CookTo.Shared.Features.ManageBookmarks.AddBookmarks;

public record AddBookmarksRequest(BookmarksDto bookmarks) : IRequest<AddBookmarksRequest.Response>
{
    public const string RouteTemplate = "api/bookmarks";
    public record Response(BookmarksDto Bookmarks);
}
