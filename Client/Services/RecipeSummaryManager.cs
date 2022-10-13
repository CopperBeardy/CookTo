using CookTo.Client.HTTPHelpers;
using CookTo.Shared;
using CookTo.Shared.Models;
using System.Text.Json;

namespace CookTo.Client.Services;

public class RecipeSummaryManager : APIRepository<RecipeSummary>
{
    IHttpClientFactory _httpClientFactory;
    public RecipeSummaryManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.SUMMARY)
    { _httpClientFactory = httpClientFactory; }

    public async Task<IEnumerable<RecipeSummary>> GetByTermsAsync(string term)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);
            var result = await httpClient.GetAsync($"/{ ControllerNames.SUMMARY}/{term}");
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var response = JsonSerializer.Deserialize<IEnumerable<RecipeSummary>>(responseBody, options);
            if(response is not null)
                return response;
            else
                return null;
        } catch(Exception ex)
        {
            var msg = ex.Message;
            return null;
        }
    }
}
