using CookTo.Client.HTTPHelpers;
using CookTo.Shared;
using CookTo.Shared.Models;
using Newtonsoft.Json;

namespace CookTo.Client.Services;

public class RecipeSummaryManager : APIRepository<RecipeSummary>
{
    IHttpClientFactory _httpClientFactory;
    public RecipeSummaryManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.SUMMARY, "Id")
    { _httpClientFactory = httpClientFactory; }

    public async Task<IEnumerable<RecipeSummary>> GetByTermsAsync(string term)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Anon);

            var result = await httpClient.GetAsync($"{ ControllerNames.SUMMARY}/{term}");
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IEnumerable<RecipeSummary>>(responseBody);
            if(response is not null)
                return response;
            else
                return new List<RecipeSummary>();
        } catch(Exception ex)
        {
            var msg = ex.Message;
            return null;
        }
    }
}
