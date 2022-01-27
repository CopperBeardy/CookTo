using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.BookmarksDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageBookmarks;

namespace CookTo.Server.Features.ManageBookmarks;

public class AddBookmarksEndpoint : EndpointBaseAsync.WithRequest<AddBookmarksRequest>.WithActionResult<AddBookmarksDto>
{
    readonly IMapper _mapper;
    readonly IBookmarksService _bookmarksService;

    public AddBookmarksEndpoint(IBookmarksService bookmarksService, IMapper mapper)
    {
        _bookmarksService = bookmarksService;
        _mapper = mapper;
    }

    [HttpPost(AddBookmarksRequest.RouteTemplate)]
    public override async Task<ActionResult<AddBookmarksDto>> HandleAsync(
        AddBookmarksRequest request,
        CancellationToken cancellationToken = default)
    {
        Bookmarks Bookmarks = _mapper.Map<Bookmarks>(request.bookmarks);
        await _bookmarksService.CreateAsync(Bookmarks);
        return Ok(Bookmarks);
    }
}
