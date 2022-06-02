using AutoMapper;
using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageFavorites;

namespace CookTo.Server.Endpoints;

public static class FavoritesEndpointsExtensions
{
    public static void FavoritesEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/api/favorites",
            async (string username, IFavoriteService service, IMapper mapper, CancellationToken token) =>
            {
                var favorites = await service.GetByUserIdAsync(username, token);

                return Results.Ok(mapper.Map<List<FavoritesDto>>(favorites));
            });

        app.MapPost(
            "/api/favorites",
            async (FavoriteDto dto, IFavoriteService service, IMapper mapper, CancellationToken token) =>
            {
                var favorites = new FavoriteRecipeDocument()
                {
                    Username = dto.Username,
                    Favorites = new List<string>() { dto.recipeId }
                };
                await service.CreateAsync(favorites, token);
                return Results.Ok();
            });

        app.MapPut(
            "/api/favorites",
            async (FavoriteDto updateFavorite, IFavoriteService service, CancellationToken token) =>
            {
                var favorites = await service.GetByIdAsync(updateFavorite.Username, token);
                if(favorites is null)
                {
                    return Results.NotFound();
                }
                favorites.Favorites.Add(updateFavorite.recipeId);
                await service.UpdateAsync(favorites, token);
                return Results.Ok();
            });
    }
}
