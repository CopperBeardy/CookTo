using AutoMapper;
using CookTo.Server.Documents.FavoritesDocument;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageFavorites;

namespace CookTo.Server.Endpoints;

public static class BookmarksEndpointsExtensions
{
    public static void BookmarksEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/bookmarks",
            async (string username, IBookmarksService service, IMapper mapper, CancellationToken token) =>
            {
                var bookmarks = await service.GetByUserIdAsync(username, token);
                return Results.Ok(mapper.Map<List<FavoritesDto>>(bookmarks));
            });
        app.MapPost(
            "/api/bookmarks",
            async (FavoriteDto dto, IBookmarksService service, IMapper mapper, CancellationToken token) =>
            {
                var bookmarks = new FavoriteRecipes()
                {
                    Username = dto.Username,
                    Favorites = new List<string>() { dto.RecipeId }
                };
                await service.CreateAsync(bookmarks, token);
                return Results.Ok();
            });
        app.MapPut(
            "/api/Bookmarks",
            async (FavoriteDto updateBookmark, IBookmarksService service, CancellationToken token) =>
            {
                var bookmarks = await service.GetByIdAsync(updateBookmark.Username, token);
                if(bookmarks is null)
                {
                    return Results.NotFound();
                }
                bookmarks.Favorites.Add(updateBookmark.RecipeId);
                await service.UpdateAsync(bookmarks, token);
                return Results.Ok();
            });
    }
}
