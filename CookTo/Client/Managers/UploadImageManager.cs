using CookTo.Client.Managers.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace CookTo.Client.Managers;

public class UploadImageManager : IUploadImageManager
{
    private readonly IHttpClientFactory _factory;

    private const string _url = $"/api/uploadimage";

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
        } catch(HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<string> UploadImage(string recipeId, IBrowserFile file)
    {
        try
        {
            var fileContent = file.OpenReadStream(file.Size, new CancellationToken());
            using var formContent = new MultipartFormDataContent();
            formContent.Add(new StreamContent(fileContent), "image", file.Name);

            var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

            var result = await httpClient.PostAsync($"{_url}/{recipeId}", formContent, new CancellationToken());
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IBrowserFile>(content);
            return response.Name;
        } catch(Exception)
        {
            throw;
        }
    }
}
