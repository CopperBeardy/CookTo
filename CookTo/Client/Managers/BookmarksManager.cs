using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageBookmarks;
using Newtonsoft.Json;

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
            var result = await httpClient.GetAsync($"{_url}/{userId}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BookmarksDto>(content);
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }


    public async Task<BookmarksDto> Insert(BookmarksDto entity)
    {
        var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

        var result = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());
        result.EnsureSuccessStatusCode();
        var content = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<BookmarksDto>(content);
        return response;
    }

    public async Task<bool> Update(BookmarksDto entityToUpdate)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);

            var result = await httpClient.PutAsJsonAsync(_url, entityToUpdate);
            result.EnsureSuccessStatusCode();
            return true;
        } catch(Exception)
        {
            throw;
        }
    }
}

