using CookTo.Client.HTTPHelpers;
using CookTo.Shared;
using CookTo.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace CookTo.Client.Services;

public class HighlightedRecipeManager : APIRepository<HighlightedRecipe>
{
    IHttpClientFactory _httpClientFactory;
    public HighlightedRecipeManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.HIGHLIGHTED, "Id")
    { _httpClientFactory = httpClientFactory; }

    public async Task<HighlightedRecipe> Get()
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);

            var result = await httpClient.GetAsync(ControllerNames.HIGHLIGHTED);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<HighlightedRecipe>(responseBody);
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
