using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageIngredients;
using CookTo.Shared.Features.ManageRecipes;
using CookTo.Shared.Features.ManageUtensils;
using Newtonsoft.Json;
using System.Text.Json;

namespace CookTo.Client.Managers;

public class RecipeManager : IRecipeManager
{
    private readonly IHttpClientFactory _factory;
    private const string _url = "/api/recipe";

    public RecipeManager(IHttpClientFactory factory) => _factory = factory;

    public async Task<RecipeDto> GetById(string id)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"{_url}/{id}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<RecipeDto>(content);
            return response;
        } catch(Exception)
        {
            return default!;
        }
    }

    public async Task<IEnumerable<RecipeDto>> GetAll()
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync(_url, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<RecipeDto>>(content);
            return response;
        } catch(Exception)
        {
            return default!;
        }
    }

    public async Task<RecipeDto> Insert(RecipeDto entity)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);
            var result = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<RecipeDto>(content);
            return response;
        } catch(Exception)
        {
            throw;
        }
    }

    public async Task<bool> Update(RecipeDto entityToUpdate)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);
            var result = await httpClient.PutAsJsonAsync(_url, entityToUpdate, new CancellationToken());
            result.EnsureSuccessStatusCode();
            return true;
        } catch(Exception)
        {
            throw;
        }
    }
}
