using CookTo.Client.Managers.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

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

            var response = await httpClient.GetFromJsonAsync<IBrowserFile>(
                $"{_url}/{recipeId}",
                new CancellationToken());
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }

    public async Task<string> UploadImage(string recipeId, IBrowserFile file)
    {
        var fileContent = file.OpenReadStream(file.Size, new CancellationToken());
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(fileContent), "image", file.Name);

        var httpClient = HttpClientFactoryHelper.CreateClient(_factory, HttpClientType.Secure);

        var response = await httpClient.PostAsync($"{_url}/{recipeId}", content, new CancellationToken());
        if(response.IsSuccessStatusCode)
        {
            var imageName = await response.Content.ReadFromJsonAsync<string>(cancellationToken: new CancellationToken());
            return imageName;
        } else
        {
            return null;
        }
    }
}
