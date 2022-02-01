using CookTo.Shared.Features.ManageRecipes.Shared;

namespace CookTo.Client.Features.ManageRecipes.Shared;

public class UploadRecipeImageHandler : IRequestHandler<UploadRecipeImageRequest, UploadRecipeImageRequest.Response>
{
    private readonly HttpClient _httpClient;

    public UploadRecipeImageHandler(HttpClient httpClient) { _httpClient = httpClient; }

    public async Task<UploadRecipeImageRequest.Response> Handle(
        UploadRecipeImageRequest request,
        CancellationToken cancellationToken)
    {
        var fileContent = request.File.OpenReadStream(request.File.Size, cancellationToken);

        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(fileContent), "image", request.File.Name);

        var response = await _httpClient.PostAsync(
            UploadRecipeImageRequest.RouteTemplate.Replace("{recipeId}", request.RecipeId),
            content,
            cancellationToken);

        if(response.IsSuccessStatusCode)
        {
            var uploadSuccessful = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
            return new UploadRecipeImageRequest.Response(uploadSuccessful);
        } else
        {
            return new UploadRecipeImageRequest.Response(string.Empty);
        }
    }
}
