using CookTo.Shared.Features.ManageIngredients.AddIngredient;
using CookTo.Shared.Features.ManageIngredients.Shared;

namespace CookTo.Client.Features.ManageIngredients.AddIngredient;

public class AddIngredientHandler : IRequestHandler<AddIngredientRequest, AddIngredientRequest.Response>
{
    private readonly HttpClient _httpClient;
    public AddIngredientHandler(HttpClient httpClient) { _httpClient = httpClient; }

    public async Task<AddIngredientRequest.Response> Handle(AddIngredientRequest request, CancellationToken token)
    {
        var response = await _httpClient.PostAsJsonAsync(AddIngredientRequest.RouteTemplate, request, token);

        if(response.IsSuccessStatusCode)
        {
            var ingredient = await response.Content.ReadFromJsonAsync<IngredientDto>(cancellationToken: token);
            return new AddIngredientRequest.Response(ingredient);
        } else
        {
            return new AddIngredientRequest.Response(new());
        }
    }
}
