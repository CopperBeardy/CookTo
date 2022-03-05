using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageCategory;
using Newtonsoft.Json;

namespace CookTo.Client.Managers;

public class CategoryManager : ICategoryManager
{
    private readonly IHttpClientFactory _factory;
    private const string _url = "/api/category";

    public CategoryManager(IHttpClientFactory factory) => _factory = factory;

    public async Task<List<CategoryDto>> GetAll()
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync(_url, new CancellationToken());
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<CategoryDto>>(content);
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<CategoryDto> GetById(string id)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"{_url}/{id}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<CategoryDto>(content);
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<CategoryDto> Insert(CategoryDto entity)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

            var result = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<CategoryDto>(content);
            return response;
        } catch(Exception)
        {
            throw;
        }
    }

    public async Task<string> Update(CategoryDto entityToUpdate)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

            var result = await httpClient.PutAsJsonAsync(_url, entityToUpdate);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<string>(content);
            return response;
        } catch(Exception)
        {
            throw;
        }
    }
}

