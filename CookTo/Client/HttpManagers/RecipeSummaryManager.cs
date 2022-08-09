using CookTo.Client.HTTPHelpers;
using CookTo.Client.HTTPManagers.Interfaces;
using CookTo.Shared;
using CookTo.Shared.Modules;
using Newtonsoft.Json;

namespace CookTo.Client.HTTPManagers;

public class RecipeSummaryManager : IRecipeSummaryManager
{
    private readonly IHttpClientFactory _factory;
    public RecipeSummaryManager(IHttpClientFactory factory) { _factory = factory; }

    public async Task<IEnumerable<RecipeSummary>> GetByTerm(string term)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"/api/{EndpointTemplate.SUMMARY}/{term}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<List<RecipeSummary>>(content);
            if(deserializedObject != null)
            {
                return deserializedObject;
            } else
            {
                return new List<RecipeSummary>();
            }
        } catch(Exception)
        {
            return default!;
        }
    }

    public async Task<IEnumerable<RecipeSummary>> GetCount(int amount)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"/api/{EndpointTemplate.SUMMARY}/{amount}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<List<RecipeSummary>>(content);
            if(deserializedObject != null)
            {
                return deserializedObject;
            } else
            {
                return new List<RecipeSummary>();
            }
        } catch(Exception)
        {
            return default!;
        }
    }
}
