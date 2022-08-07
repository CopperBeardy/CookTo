using Microsoft.AspNetCore.Components.Authorization;

namespace CookTo.Client.Modules.Auth;

public static class GetUser
{
    public static async Task<string?> GetUserName(AuthenticationStateProvider stateProvider)
    {
        var state = await stateProvider.GetAuthenticationStateAsync();
        var user = state.User;
        if (user.Identity is not null)
        {
            var username = user.Identity.Name;
            return username;
        }
        return string.Empty;
    }
}
