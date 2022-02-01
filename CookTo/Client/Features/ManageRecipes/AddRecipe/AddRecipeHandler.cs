using CookTo.Shared.Features.ManageRecipes.AddRecipe;
using CookTo.Shared.Features.ManageRecipes.Shared;

namespace CookTo.Client.Features.ManageRecipes.AddRecipe;

public class AddRecipeHandler : IRequestHandler<AddRecipeRequest, AddRecipeRequest.Response>
{
    private readonly HttpClient _httpClient;
    public AddRecipeHandler(HttpClient httpClient) { _httpClient = httpClient; }

    public async Task<AddRecipeRequest.Response> Handle(AddRecipeRequest request, CancellationToken token)
    {
        var response = await _httpClient.PostAsJsonAsync(AddRecipeRequest.RouteTemplate, request);

        if(response.IsSuccessStatusCode)
        {
            var Recipe = await response.Content.ReadFromJsonAsync<RecipeDto>(cancellationToken: token);
            return new AddRecipeRequest.Response(Recipe);
        } else
        {
            return new AddRecipeRequest.Response(null);
        }
    }
}