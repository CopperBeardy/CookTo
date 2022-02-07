using AutoMapper;
using CookTo.Server.Mappings;
using CookTo.Server.Services;
using CookTo.Server.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Web;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection(nameof(MongoSettings))).AddOptions();

//var mongoSettings = builder.Configuration.GetSection(nameof(MongoSettings));

builder.Services.AddScoped<ICookToDbContext, CookToDbContext>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IBookmarksService, BookmarksService>();
builder.Services.AddScoped<IUtensilService, UtensilService>();
builder.Services
    .AddCors(
        policy =>
        {
            policy.AddPolicy(
                "CorsPolicy",
                opt => opt
                .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("X-Pagination"));
        });

builder.Services
    .AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.Load("CookTo.Shared")));

var mapperConfiguration = new MapperConfiguration(
    config =>
    {
        config.AddProfile(new RecipeProfile());
        config.AddProfile(new BookmarksProfile());
        config.AddProfile(new IngredientProfile());
        config.AddProfile(new UtensilProfile());
    });
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
} else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseStaticFiles(
    new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
        RequestPath = new Microsoft.AspNetCore.Http.PathString("/Images")
    });

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
