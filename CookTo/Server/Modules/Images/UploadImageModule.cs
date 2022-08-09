using CookTo.Server.Modules.Recipes.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CookTo.Server.Modules.Images;

public class UploadImageModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.UPLOADIMAGE);
        api.MapPost(
            "/",
            async (ImageUpload dto, IRecipeService service, CancellationToken token) =>
            {
                var recipe = await service.GetByIdAsync(dto.RecipeId, token);
                if(recipe is null)
                    return Results.BadRequest("Recipe does not exist.");

                if(dto.Image.Length == 0)
                    return Results.BadRequest("No image found.");

                var filename = $"{Guid.NewGuid()}.jpg";
                var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

                var resizeOptions = new ResizeOptions { Mode = ResizeMode.Stretch, Size = new Size(640, 426) };

                using var image = Image.Load(dto.Image);
                image.Mutate(x => x.Resize(resizeOptions));
                await image.SaveAsJpegAsync(saveLocation, cancellationToken: token);

                if(!string.IsNullOrWhiteSpace(recipe.Image))
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", recipe.Image));

                recipe.Image = filename;
                await service.UpdateAsync(recipe, token);

                return Results.Ok(recipe.Image);
            })
            .RequireAuthorization();
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}
