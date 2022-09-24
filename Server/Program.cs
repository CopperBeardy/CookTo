using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;
using CookTo.Shared.Models.ManageIngredients;
using CookTo.Shared.Models.ManageRecipes;
using CookTo.Shared.Models.ManageTips;
using CookTo.Shared.Models.ManageUtensils;
using CookTo.Shared.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Web;
using MongoFramework;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

//builder.Services
//    .Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);


builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection(nameof(MongoSettings))).AddOptions();

builder.Services
    .AddEndpointsApiExplorer()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.Load("CookTo.Shared")));


builder.Services.AddTransient<CookToDbContext, CookToDbContext>();
builder.Services.AddTransient<MongoRepository<Ingredient>>();
builder.Services.AddTransient<MongoRepository<Cuisine>>();
builder.Services.AddTransient<MongoRepository<Category>>();
builder.Services.AddTransient<MongoRepository<Utensil>>();
builder.Services.AddTransient<MongoRepository<Tip>>();
builder.Services.AddTransient<MongoRepository<Recipe>>();

builder.Services
    .AddSwaggerGen(
        c =>
        {
            c.SwaggerDoc("v1", new() { Title = "CookToApi", Version = "v1" });
        });

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();


if(app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CookTo API V1"));
} else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseStaticFiles(
    new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
        RequestPath = new PathString("/Images")
    });

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
