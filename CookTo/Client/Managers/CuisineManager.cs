using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageCuisine;
using Newtonsoft.Json;

namespace CookTo.Client.Managers; public class CuisineManager : ICuisineManager
{
    private readonly IHttpClientFactory _factory;
    private const string _url = "/api/cuisine";

    public CuisineManager(IHttpClientFactory factory) => _factory = factory;

    public async Task<List<CuisineDto>> GetAll()
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync(_url, new CancellationToken());
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<CuisineDto>>(content);
            return response;
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<CuisineDto> GetById(string id)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"{_url}/{id}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<CuisineDto>(content);
            return response;
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<CuisineDto> Insert(CuisineDto entity)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

            var result = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<CuisineDto>(content);
            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> Update(CuisineDto entityToUpdate)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

            var result = await httpClient.PutAsJsonAsync(_url, entityToUpdate);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<string>(content);
            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

