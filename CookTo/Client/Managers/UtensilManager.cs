using CookTo.Client.Managers.Interfaces;
using CookTo.Shared.Features.ManageUtensils;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

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

            var result = await httpClient.GetAsync(_url, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<UtensilDto>>(content);
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }


    public async Task<UtensilDto> Insert(UtensilDto entity)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);
            var result = await httpClient.PostAsJsonAsync(_url, entity, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<UtensilDto>(content);
            return response;
        } catch(Exception)
        {
            throw;
        }
    }
}
