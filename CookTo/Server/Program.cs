using AutoMapper;
using CookTo.Server.Modules.Categories;
using CookTo.Server.Modules.Categories.MapperProfile;
using CookTo.Server.Modules.Categories.Services;
using CookTo.Server.Modules.Cuisines;
using CookTo.Server.Modules.Cuisines.MapperProfile;
using CookTo.Server.Modules.Cuisines.Services;
using CookTo.Server.Modules.Images;
using CookTo.Server.Modules.Ingredients;
using CookTo.Server.Modules.Ingredients.MapperProfile;
using CookTo.Server.Modules.Ingredients.Services;
using CookTo.Server.Modules.Recipes;
using CookTo.Server.Modules.Recipes.MapperProfile;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Server.Modules.Utensils;
using CookTo.Server.Modules.Utensils.MapperProfile;
using CookTo.Server.Modules.Utensils.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Web;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection(nameof(MongoSettings))).AddOptions();

builder.Services
    .AddEndpointsApiExplorer()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.Load("CookTo.Shared")));

builder.Services.AddScoped<ICookToDbContext, CookToDbContext>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IUtensilService, UtensilService>();
builder.Services.AddScoped<ICuisineService, CuisineService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
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


builder.Services.AddAutoMapper(
       typeof(RecipeProfile),
       typeof(IngredientProfile),
       typeof(UtensilProfile),
       typeof(CuisineProfile),
       typeof(CategoryProfile)
    );

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.IngredientEndpoints();
app.UtensilEndpoints();
app.RecipeEndpoints();
app.HighlightedRecipeEndpoints();
app.UploadImageEndpoints();
app.CuisineEndpoints();
app.CategoryEndpoints();
app.RecipeSummaryEndpoints();

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
