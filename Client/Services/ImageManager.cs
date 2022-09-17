using CookTo.Client.HTTPHelpers;
using CookTo.Shared;
using CookTo.Shared.Models;
using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageRecipes;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;

namespace CookTo.Client.Services; public class ImageManager : IImageManager
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ImageManager(IHttpClientFactory httpClientFactory) { _httpClientFactory = httpClientFactory; }


    public async Task<string> UploadImage(string recipeId, IBrowserFile file)
    {
        try
        {
            MemoryStream ms = new();
            await file.OpenReadStream(file.Size).CopyToAsync(ms);
            var dto = new ImageUpload() { RecipeId = recipeId, Image = ms.ToArray() };

            var httpClient = HttpNamedClientFactoryHelper.CreateClient(_httpClientFactory, HttpClientType.Secure);

            var result = await httpClient.PostAsJsonAsync(ControllerNames.IMAGE, dto);
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
