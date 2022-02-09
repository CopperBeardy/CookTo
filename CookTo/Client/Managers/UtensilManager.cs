using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageUtensils;

namespace CookTo.Client.Managers;

public class UtensilManager : IUtensilManager
{
    private readonly IHttpClientFactory _factory;
    private const string _url = "/api/utensil";

    public UtensilManager(IHttpClientFactory factory) => _factory = factory;

    public async Task<IEnumerable<UtensilDto>> GetAll()
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);

            var response = await httpClient.GetFromJsonAsync<List<UtensilDto>>(_url, new CancellationToken());
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }


    public async Task<UtensilDto> Insert(UtensilDto entity)
    {
        var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

        var response = await httpClient.PostAsJsonAsync(_url, entity);

        if(response.IsSuccessStatusCode)
        {
            var t = await response.Content.ReadFromJsonAsync<UtensilDto>(cancellationToken: new CancellationToken());
            return t;
        } else
        {
            return null;
        }
    }
}
