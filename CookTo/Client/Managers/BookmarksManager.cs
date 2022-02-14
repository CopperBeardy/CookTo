using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageFavorites;
using Newtonsoft.Json;

namespace CookTo.Client.Managers;

public class BookmarksManager : IBookmarksManager
{
    private readonly IHttpClientFactory _factory;

    private const string _url = "/api/bookmarks";
    public BookmarksManager(IHttpClientFactory factory) => _factory = factory;

    public async Task<FavoritesDto> GetById(string userId)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"{_url}/{userId}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<FavoritesDto>(content);
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }


    public async Task<bool> Insert(FavoriteDto dto)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);
            var result = await httpClient.PostAsJsonAsync(_url, dto, new CancellationToken());
            result.EnsureSuccessStatusCode();
            return true;
        } catch(Exception)
        {
            throw;
        }
    }

    public async Task<bool> Update(FavoriteDto dto)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);

            var result = await httpClient.PutAsJsonAsync(_url, dto);
            result.EnsureSuccessStatusCode();
            return true;
        } catch(Exception)
        {
            throw;
        }
    }
}

