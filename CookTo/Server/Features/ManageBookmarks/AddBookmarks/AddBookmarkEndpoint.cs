using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.BookmarksDocument;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageBookmarks.AddBookmarks;
using CookTo.Shared.Features.ManageBookmarks.Shared;

namespace CookTo.Server.Features.ManageBookmarks.AddBookmarks;

public class AddBookmarksEndpoint : EndpointBaseAsync.WithRequest<AddBookmarksRequest>.WithActionResult<BookmarksDto>
{
    readonly IBookmarksService _bookmarksService;
    readonly IMapper _mapper;
    public AddBookmarksEndpoint(IBookmarksService bookmarksService,IMapper mapper) {
        _bookmarksService = bookmarksService;
        _mapper = mapper;
    }

    [HttpPost(AddBookmarksRequest.RouteTemplate)]
    public override async Task<ActionResult<BookmarksDto>> HandleAsync(
        AddBookmarksRequest request,
        CancellationToken cancellationToken = default)
    {
        Bookmarks bookmarks = _mapper.Map<Bookmarks>(request.bookmarks);
        await _bookmarksService.CreateAsync(bookmarks, cancellationToken);
        return Ok(_mapper.Map<BookmarksDto>(bookmarks));
    }
}
