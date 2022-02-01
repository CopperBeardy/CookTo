using CookTo.Shared.Features.ManageBookmarks.AddBookmarks;
using CookTo.Shared.Features.ManageBookmarks.Shared;

namespace CookTo.Client.Features.ManageBookmarks.AddBookmarks;

public class AddBookmarksHandler : IRequestHandler<AddBookmarksRequest, AddBookmarksRequest.Response>
{
    private readonly HttpClient _httpClient;
    public AddBookmarksHandler(HttpClient httpClient) { _httpClient = httpClient; }

    public async Task<AddBookmarksRequest.Response> Handle(AddBookmarksRequest request, CancellationToken token)
    {
        var response = await _httpClient.PostAsJsonAsync(AddBookmarksRequest.RouteTemplate, request);

        if(response.IsSuccessStatusCode)
        {
            var bookmarks = await response.Content.ReadFromJsonAsync<BookmarksDto>(cancellationToken: token);
            return new AddBookmarksRequest.Response(bookmarks);
        } else
        {
            return new AddBookmarksRequest.Response(new());
        }
    }
}
