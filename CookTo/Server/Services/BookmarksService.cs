using CookTo.Server.Services.Interfaces;
using MongoDB.Bson;

namespace CookTo.Server.Services;
public class BookmarksService : BaseService<Bookmarks>, IBookmarksService
{
	public BookmarksService(ICookToDbContext dbContext) : base(dbContext)
	{

	}

	public async Task<Bookmarks> GetByUserIdAsync(string id) => await dbCollection.Find(e => e.UserId.Equals(id)).FirstOrDefaultAsync();

}
