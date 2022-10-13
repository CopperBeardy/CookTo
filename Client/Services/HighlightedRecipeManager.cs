using CookTo.Client.HTTPHelpers;
using CookTo.Shared;
using CookTo.Shared.Models;
using System.Text.Json;

namespace CookTo.Client.Services;

public class HighlightedRecipeManager : APIRepository<HighlightedRecipe>
{
    IHttpClientFactory _httpClientFactory;
    public HighlightedRecipeManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.HIGHLIGHTED)
    { _httpClientFactory = httpClientFactory; }

    public async Task<HighlightedRecipe> Get()
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);

            var result = await httpClient.GetAsync(ControllerNames.HIGHLIGHTED);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var response = JsonSerializer.Deserialize<HighlightedRecipe>(responseBody, options);
            if(response is not null)
                return response;
            else
                return new ();
        } catch(Exception ex)
        {
            var msg = ex.Message;
            return null;
        }
    }
}
