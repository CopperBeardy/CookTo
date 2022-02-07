using CookTo.Shared.Features.ManageIngredients.GetIngredients;

namespace CookTo.Client.Features.ManageIngredients.GetIngredient;

public class GetIngredientsHandler : IRequestHandler<GetIngredientsRequest, GetIngredientsRequest.Response?>
{
    private readonly HttpClient _httpClient;

    public GetIngredientsHandler(IHttpClientFactory httpClientFactory)
    { _httpClient = httpClientFactory.CreateClient("CookTo.ServerAPIAnonymous"); }

    public async Task<GetIngredientsRequest.Response?> Handle(
        GetIngredientsRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GetIngredientsRequest.Response>(
                GetIngredientsRequest.RouteTemplate);
            return response;
        } catch(HttpRequestException)
        {
            return default!;
        }
    }
}