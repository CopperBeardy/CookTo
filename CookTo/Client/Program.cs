using Blazored.LocalStorage;
using CookTo.Client;
using CookTo.Client.Managers;
using CookTo.Client.Managers.Interfaces;
using CookTo.Client.State;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddHttpClient("CookTo.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services
    .AddHttpClient(
        "CookTo.ServerAPIAnonymous",
        client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CookTo.ServerAPI"));

builder.Services
    .AddMsalAuthentication(
        options =>
        {
            builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
            options.ProviderOptions.DefaultAccessTokenScopes
                .Add("https://cookto.onmicrosoft.com/39f9835a-542c-4737-a4c2-05e68f4ecf18/CookToB2CServer.Access");
        });

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IIngredientManager, IngredientManager>();
builder.Services.AddScoped<IUtensilManager, UtensilManager>();
builder.Services.AddScoped<IRecipeManager, RecipeManager>();
builder.Services.AddScoped<IHighlightedRecipeManager, HighlightedRecipeManager>();
builder.Services.AddScoped<IRecipeSummaryManager, RecipeSummaryManager>();
builder.Services.AddScoped<IFavoritesManager, FavoritesManager>();
builder.Services.AddScoped<IUploadImageManager, UploadImageManager>();
builder.Services.AddScoped<ICuisineManager, CuisineManager>();


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AppState>();
await builder.Build().RunAsync();
