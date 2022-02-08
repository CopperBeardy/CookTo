using CookTo.Shared.Features.ManageBookmarks.Shared;


namespace CookTo.Client.Managers.Interfaces;

public interface IBookmarksManager
{
    Task<BookmarksDto> GetById(string userId);

    Task<BookmarksDto> Insert(BookmarksDto entity);

    Task<BookmarksDto> Update(BookmarksDto entityToUpdate);
}

