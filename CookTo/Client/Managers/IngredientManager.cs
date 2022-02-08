using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageIngredients.Shared;

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
            var response = await httpClient.GetFromJsonAsync<List<IngredientDto>>(_url, new CancellationToken());
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }


    public async Task<IngredientDto> Insert(IngredientDto entity)
    {
        var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

        var response = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());

        if(response.IsSuccessStatusCode)
        {
            var t = await response.Content.ReadFromJsonAsync<IngredientDto>(cancellationToken: new CancellationToken());
            return t;
        } else
        {
            return null;
        }
    }

    public async Task<IngredientDto> Update(IngredientDto entityToUpdate)
    {
        var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

        var response = await httpClient.PutAsJsonAsync(_url, entityToUpdate);

        if(response.IsSuccessStatusCode)
        {
            var Ingredient = await response.Content
                .ReadFromJsonAsync<IngredientDto>(cancellationToken: new CancellationToken());
            return Ingredient;
        } else
        {
            return null;
        }
    }
}

