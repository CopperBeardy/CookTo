using CookTo.Shared.Models;

namespace CookTo.Client.Services;

public class BookmarksManager : APIManager<Bookmarks>
{
	public BookmarksManager(HttpClient client) : base(client,nameof(Bookmarks))
	{

	}
}
