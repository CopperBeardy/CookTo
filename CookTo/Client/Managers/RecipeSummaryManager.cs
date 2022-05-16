using CookTo.Shared.Features.ManageRecipes;
using Newtonsoft.Json;

namespace CookTo.Client.Managers;

public class RecipeSummaryManager : IRecipeSummaryManager
{
    private readonly IHttpClientFactory _factory;
    public RecipeSummaryManager(IHttpClientFactory factory) { _factory = factory; }

    public async Task<IEnumerable<RecipeSummaryDto>> GetByTerm(string term)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"/api/searchrecipes/{term}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<RecipeSummaryDto>>(content);
            return response;
        } catch(Exception)
        {
            return default!;
        }
    }

    public async Task<IEnumerable<RecipeSummaryDto>> GetCount(int amount)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"/api/recipes/{amount}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<RecipeSummaryDto>>(content);
            return response;
        } catch(Exception)
        {
            return default!;
        }
    }
}
