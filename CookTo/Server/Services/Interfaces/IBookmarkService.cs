using CookTo.Server.Documents.BookmarksDocument;

namespace CookTo.Server.Services.Interfaces;

public interface IBookmarksService : IBaseService<Bookmarks>
{
    Task<Bookmarks> GetByUserIdAsync(string id);
}
