using CookTo.Shared.Features.ManageFavorites;

namespace CookTo.Client.Managers.Interfaces;

public interface IBookmarksManager
{
    Task<FavoritesDto> GetById(string userid);

    Task<bool> Insert(FavoriteDto dto);

    Task<bool> Update(FavoriteDto dto);
}

