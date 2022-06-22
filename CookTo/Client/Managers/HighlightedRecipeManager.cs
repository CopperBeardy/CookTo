using CookTo.Shared.Modules.ManageRecipes;
using Newtonsoft.Json;

namespace CookTo.Client.Managers;

public class HighlightedRecipeManager : IHighlightedRecipeManager
{
    private readonly IHttpClientFactory _factory;

    private const string _url = "/api/highlighted";


    public HighlightedRecipeManager(IHttpClientFactory factory) { _factory = factory; }

    public async Task<HighlightedRecipe?> GetHighlighted()
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);
            var result = await httpClient.GetAsync(_url, new CancellationToken());
                result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<HighlightedRecipe>(content);
            if (deserializedObject != null)
            {
                return deserializedObject;
            }
            else
            {
                return null;
            }
        } catch(Exception)
        {
            return default!;
        }
    }
}
