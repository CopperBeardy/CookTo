using MediatR;

namespace CookTo.Shared.Features.ManageBookmarks;

public record AddBookmarksRequest(AddBookmarksDto bookmarks) : IRequest<AddBookmarksRequest.Response>
{
    public const string RouteTemplate = "api/Bookmarks";
    public record Response(AddBookmarksDto Bookmarks);
}
