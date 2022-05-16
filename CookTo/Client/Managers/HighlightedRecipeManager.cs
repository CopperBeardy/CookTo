using CookTo.Shared.Features.ManageRecipes;
using Newtonsoft.Json;

namespace CookTo.Client.Managers;

public class HighlightedRecipeManager : IHighlightedRecipeManager
{
    private readonly IHttpClientFactory _factory;

    private const string _url = "/api/highlighted";


    public HighlightedRecipeManager(IHttpClientFactory factory) { _factory = factory; }

    public async Task<HighlightedRecipeDto> GetHighlighted()
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync(_url, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<HighlightedRecipeDto>(content);
            return response;
        } catch(Exception)
        {
            return default!;
        }
    }
}
