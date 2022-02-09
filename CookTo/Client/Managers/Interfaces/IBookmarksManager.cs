using CookTo.Shared.Features.ManageBookmarks;

namespace CookTo.Client.Managers.Interfaces;

public interface IBookmarksManager
{
    Task<BookmarksDto> GetById(string userId);

    Task<BookmarksDto> Insert(BookmarksDto entity);

    Task<bool> Update(BookmarksDto entityToUpdate);
}

