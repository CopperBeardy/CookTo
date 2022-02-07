using CookTo.Shared.Features.ManageRecipes.EditRecipe;

namespace CookTo.Client.Features.ManageRecipes.EditRecipe;

public class EditRecipeHandler : IRequestHandler<EditRecipeRequest, EditRecipeRequest.Response>
{
    private readonly HttpClient _httpClient;
    public EditRecipeHandler(HttpClient httpClient) { _httpClient = httpClient; }

    public async Task<EditRecipeRequest.Response> Handle(EditRecipeRequest request, CancellationToken token)
    {
        var response = await _httpClient.PutAsJsonAsync(EditRecipeRequest.RouteTemplate, request);

        if(response.IsSuccessStatusCode)
        {
            return new EditRecipeRequest.Response(true);
        } else
        {
            return new EditRecipeRequest.Response(false);
        }
    }
}