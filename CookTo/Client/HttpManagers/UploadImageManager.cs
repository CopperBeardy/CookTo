using CookTo.Client.HTTPHelpers;
using CookTo.Client.HTTPManagers.Interfaces;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace CookTo.Client.HTTPManagers;

public class UploadImageManager : IUploadImageManager
{
    private readonly IHttpClientFactory _factory;

    private const string _url = $"/api/{EndpointTemplate.UPLOADIMAGE}";

    public UploadImageManager(IHttpClientFactory factory) => _factory = factory;

    public async Task<IBrowserFile?> GetImage(string recipeId)
    {
        try
        {
            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_factory, HttpClientType.Anon);

            var result = await httpClient.GetAsync($"{_url}/{recipeId}", new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<IBrowserFile>(content);
            return deserializedObject;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<string> UploadImage(string recipeId, IBrowserFile file)
    {
        try
        {
            MemoryStream ms = new();
            await file.OpenReadStream(file.Size).CopyToAsync(ms);
            var dto = new ImageUpload() { RecipeId = recipeId, Image = ms.ToArray() };

            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

            var result = await httpClient.PostAsJsonAsync(_url, dto, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            return content;
        } catch(Exception)
        {
            throw;
        }
    }
}
