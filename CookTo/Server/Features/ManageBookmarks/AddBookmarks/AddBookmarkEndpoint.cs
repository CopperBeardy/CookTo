using Ardalis.ApiEndpoints;
using CookTo.Server.Documents.BookmarksDocument;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageBookmarks.AddBookmarks;
using CookTo.Shared.Features.ManageBookmarks.Shared;

namespace CookTo.Server.Features.ManageBookmarks.AddBookmarks;

public class AddBookmarksEndpoint : EndpointBaseAsync.WithRequest<AddBookmarksRequest>.WithActionResult<BookmarksDto>
{
    readonly IBookmarksService _bookmarksService;

    public AddBookmarksEndpoint(IBookmarksService bookmarksService) { _bookmarksService = bookmarksService; }

    [HttpPost(AddBookmarksRequest.RouteTemplate)]
    public override async Task<ActionResult<BookmarksDto>> HandleAsync(
        AddBookmarksRequest request,
        CancellationToken cancellationToken = default)
    {
        Bookmarks bookmarks = BookmarksMapping.FromDtoToBookmarks(request.bookmarks);
        await _bookmarksService.CreateAsync(bookmarks, cancellationToken);
        return Ok(BookmarksMapping.FromBookmarksToDto(bookmarks));
    }
}
