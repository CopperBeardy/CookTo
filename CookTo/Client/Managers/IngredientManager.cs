using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageIngredients;
using CookTo.Shared.Features.ManageRecipes;
using Newtonsoft.Json;

namespace CookTo.Client.Managers;

public class IngredientManager : IIngredientManager
{
    private readonly IHttpClientFactory _factory;
    private const string _url = "/api/ingredient";

    public IngredientManager(IHttpClientFactory factory) => _factory = factory;

    public async Task<IEnumerable<IngredientDto>> GetAll()
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync(_url, new CancellationToken());
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<IngredientDto>>(content);
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<IngredientDto> GetById(string id)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"{_url}/{id}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IngredientDto>(content);
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<string> Insert(IngredientDto entity)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

            var result = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<string>(content);
            return response;
        } catch(Exception)
        {
            throw;
        }
    }

    public async Task<string> Update(IngredientDto entityToUpdate)
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

