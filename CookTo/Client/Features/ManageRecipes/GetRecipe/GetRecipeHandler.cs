using CookTo.Shared.Features.ManageRecipes.GetRecipes;

namespace CookTo.Client.Features.ManageRecipes.GetRecipe;

public class GetRecipeHandler : IRequestHandler<GetRecipeRequest, GetRecipeRequest.Response?>
{
    private readonly HttpClient _httpClient;

    public GetRecipeHandler(IHttpClientFactory httpClientFactory)
    { _httpClient = httpClientFactory.CreateClient("CookTo.ServerAPIAnonymous"); }

    public async Task<GetRecipeRequest.Response?> Handle(GetRecipeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GetRecipeRequest.Response>(
                GetRecipeRequest.RouteTemplate.Replace("{recipeId}", request.recipeId),
                cancellationToken);
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }
}
