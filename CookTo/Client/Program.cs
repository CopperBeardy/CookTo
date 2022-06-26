using Blazored.LocalStorage;
using Blazored.Modal;
using CookTo.Client;
using CookTo.Client.HttpManagers;
using CookTo.Client.HttpManagers.Interfaces;
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

builder.Services.AddScoped<CategoryManager>();
builder.Services.AddScoped<IngredientManager>();
builder.Services.AddScoped<UtensilManager>();
builder.Services.AddScoped<RecipeManager>();
builder.Services.AddScoped<CuisineManager>();
builder.Services.AddScoped<HighlightedRecipeManager>();
builder.Services.AddScoped<IRecipeSummaryManager, RecipeSummaryManager>();
builder.Services.AddScoped<IUploadImageManager, UploadImageManager>();

builder.Services.AddScoped<AppState>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();
await builder.Build().RunAsync();
