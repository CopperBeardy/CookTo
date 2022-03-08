using CookTo.Shared.Features.ManageRecipes;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace CookTo.Client.Managers;

public class UploadImageManager : IUploadImageManager
{
    private readonly IHttpClientFactory _factory;

    private const string _url = "/api/upload";

    public UploadImageManager(IHttpClientFactory factory) => _factory = factory;

    public async Task<IBrowserFile> GetImage(string recipeId)
    {
        try
        {
            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);

            var result = await httpClient.GetAsync($"{_url}/{recipeId}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IBrowserFile>(content);
            return response;
        }
        catch (HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<string> UploadImage(string recipeId, IBrowserFile file)
    {
        try
        {
            MemoryStream ms = new MemoryStream();
            await file.OpenReadStream(file.Size).CopyToAsync(ms);
            var dto = new ImageUploadDto() { RecipeId = recipeId, Image = ms.ToArray() };

            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

            var result = await httpClient.PostAsJsonAsync(_url, dto, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            return content;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
