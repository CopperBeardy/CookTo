using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageRecipes;
using Newtonsoft.Json;


namespace CookTo.Client.Managers;

public class RecipeManager : IRecipeManager
{
    private readonly IHttpClientFactory _factory;

    private const string _url = "/api/recipe";

    public RecipeManager(IHttpClientFactory factory) { _factory = factory; }

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
        }
        catch (Exception)
        {
            return default!;
        }
    }

    public async Task<IEnumerable<RecipeSummaryDto>> GetAll()
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync(_url, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<RecipeSummaryDto>>(content);
            return response;
        }
        catch (Exception)
        {
            return default!;
        }
    }

    public async Task<RecipeDto> Insert(RecipeDto recipe)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);
            var result = await httpClient.PostAsJsonAsync(_url, recipe, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<RecipeDto>(content);
            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Update(RecipeDto recipeToUpdate)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);
            var result = await httpClient.PutAsJsonAsync(_url, recipeToUpdate, new CancellationToken());
            result.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
