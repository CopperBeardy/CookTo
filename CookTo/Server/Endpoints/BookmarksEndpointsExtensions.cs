using AutoMapper;
using CookTo.Server.Documents.BookmarksDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageBookmarks;

namespace CookTo.Server.Endpoints;

public static class BookmarksEndpointsExtensions
{
    public static void BookmarksEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/bookmarks",
            async (IBookmarksService service, IMapper mapper, CancellationToken token) =>
            {
                var bookmarks = await service.GetAllAsync(token);
                return Results.Ok(mapper.Map<List<BookmarksDto>>(bookmarks));
            });
        app.MapPost(
            "/api/bookmarks",
            async (BookmarksDto bookmarks, IBookmarksService service, IMapper mapper, CancellationToken token) =>
            {
                await service.CreateAsync(mapper.Map<Bookmarks>(bookmarks), token);
                return Results.Created($"/api/bookmarks", bookmarks);
            });
        app.MapPut(
            "/api/Bookmarks",
            async (BookmarksDto updateBookmarks, IBookmarksService service, IMapper mapper, CancellationToken token) =>
            {
                var bookmarks = await service.GetByIdAsync(updateBookmarks.UserId, token);
                if(bookmarks is null)
                {
                    return Results.NotFound();
                }
                await service.UpdateAsync(mapper.Map<Bookmarks>(updateBookmarks), token);
                return Results.NoContent();
            });
    }
}
