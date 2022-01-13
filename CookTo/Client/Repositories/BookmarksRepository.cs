using CookTo.Shared.Models;
using System.Text.Json;

namespace CookTo.Client.Repositories;

public class BookmarksRepository : BaseRepository<Bookmarks>
{
	readonly HttpClient client;
	public BookmarksRepository(HttpClient client) : base(client, nameof(Bookmarks)) { this.client = client; }

	public async Task<Bookmarks> GetByUserIdAsync(int id)
	{
		try
		{
			var result = await client.GetAsync($"/api/{nameof(Bookmarks)}/{id}");
			result.EnsureSuccessStatusCode();
			string responseBody = await result.Content.ReadAsStringAsync();
			var response = JsonSerializer.Deserialize<Bookmarks>(responseBody);
			return response;
		} catch(Exception)
		{
			return null;
		}
	}
}
