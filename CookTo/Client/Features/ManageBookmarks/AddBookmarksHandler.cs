
namespace CookTo.Client.Features.ManageBookmarks;

public class AddBookmarksHandler : IRequestHandler<AddBookmarksRequest, AddBookmarksRequest.Response>
{
    private readonly HttpClient _httpClient;
    public AddBookmarksHandler(HttpClient httpClient) { _httpClient = httpClient; }

    public async Task<AddBookmarksRequest.Response> Handle(AddBookmarksRequest request, CancellationToken token)
    {
        var response = await _httpClient.PostAsJsonAsync(AddBookmarksRequest.RouteTemplate, request);

        if(response.IsSuccessStatusCode)
        {
            var bookmarks = await response.Content.ReadFromJsonAsync<AddBookmarksDto>(cancellationToken: token);
            return new AddBookmarksRequest.Response(bookmarks);
        } else
        {
            return new AddBookmarksRequest.Response(new());
        }
    }
}
