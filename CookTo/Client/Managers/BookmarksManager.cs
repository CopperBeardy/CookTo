using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageBookmarks.Shared;


namespace CookTo.Client.Managers;

public class BookmarksManager : IBookmarksManager
{
    private readonly IHttpClientFactory _factory;

    private const string _url = "/api/bookmarks";
    public BookmarksManager(IHttpClientFactory factory) => _factory = factory;

    public async Task<BookmarksDto> GetById(string userId)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var response = await httpClient.GetFromJsonAsync<BookmarksDto>($"{_url}/{userId}", new CancellationToken());
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }


    public async Task<BookmarksDto> Insert(BookmarksDto entity)
    {
        var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

        var response = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());

        if(response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BookmarksDto>(cancellationToken: new CancellationToken());
        } else
        {
            return null;
        }
    }

    public async Task<BookmarksDto> Update(BookmarksDto entityToUpdate)
    {
        var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);

        var response = await httpClient.PutAsJsonAsync(_url, entityToUpdate);

        if(response.IsSuccessStatusCode)
        {
            var Bookmarks = await response.Content
                .ReadFromJsonAsync<BookmarksDto>(cancellationToken: new CancellationToken());
            return Bookmarks;
        } else
        {
            return null;
        }
    }
}

