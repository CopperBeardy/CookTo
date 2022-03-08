using Microsoft.AspNetCore.Components.Authorization;

namespace CookTo.Client.Features.Auth;

public static class GetUser
{
    public static async Task<string> GetUserName(AuthenticationStateProvider stateProvider)
    {
        var state = await stateProvider.GetAuthenticationStateAsync();
        var user = state.User;
        var username = user.Identity.Name;
        return username;
    }
}
