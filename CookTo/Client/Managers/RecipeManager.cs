using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageRecipes.Shared;


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
            var response = await httpClient.GetFromJsonAsync<RecipeDto>($"{_url}/{id}", new CancellationToken());
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<IEnumerable<RecipeDto>> GetAll()
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var response = await httpClient.GetFromJsonAsync<List<RecipeDto>>(_url, new CancellationToken());
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<RecipeDto> Insert(RecipeDto entity)
    {
        var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);
        var response = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());

        if(response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<RecipeDto>(cancellationToken: new CancellationToken());
        } else
        {
            return null;
        }
    }

    public async Task<RecipeDto> Update(RecipeDto entityToUpdate)
    {
        var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

        var response = await httpClient.PutAsJsonAsync(_url, entityToUpdate, new CancellationToken());

        if(response.IsSuccessStatusCode)
        {
            var Recipe = await response.Content.ReadFromJsonAsync<RecipeDto>(cancellationToken: new CancellationToken());
            return Recipe;
        } else
        {
            return null;
        }
    }
}
