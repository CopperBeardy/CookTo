using Blazored.LocalStorage;
using Blazored.Modal;
using CookTo.Client;
using CookTo.Client.Services;
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
    .AddMsalAuthentication(options =>
    {
        builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
        options.ProviderOptions.DefaultAccessTokenScopes
            .Add("https://cookto.onmicrosoft.com/2d23510f-1f37-4e29-8d76-349682b13841/CookToB2CServer.Access");
    });

builder.Services.AddScoped<CategoryManager>();
builder.Services.AddScoped<IngredientManager>();
builder.Services.AddScoped<UtensilManager>();
builder.Services.AddScoped<RecipeManager>();
builder.Services.AddScoped<CuisineManager>();
builder.Services.AddScoped<HighlightedRecipeManager>();
builder.Services.AddScoped<RecipeSummaryManager>();
builder.Services.AddScoped<IImageManager, ImageManager>();

builder.Services.AddScoped<AppState>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
