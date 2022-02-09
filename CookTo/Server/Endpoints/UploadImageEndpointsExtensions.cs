using AutoMapper;
using CookTo.Server.Services.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CookTo.Server.Endpoints;

public static class UploadImageEndpointsExtensions
{
    public static void UploadImageEndpoints(this WebApplication app)
    {
        app.MapPost(
            "/api/uploadimage/{recipeId}",
            async (
                string recipeId,
                IFormFile uploadedFile,
                IRecipeService service,
                IMapper mapper,
                CancellationToken token) =>
            {
                var recipe = await service.GetByIdAsync(recipeId, token);
                if(recipe is null)
                {
                    return Results.BadRequest("Recipe does not exist.");
                }

                var file = uploadedFile;
                if(file.Length == 0)
                {
                    return Results.BadRequest("No image found.");
                }

                var filename = $"{Guid.NewGuid()}.jpg";
                var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

                var resizeOptions = new ResizeOptions { Mode = ResizeMode.Pad, Size = new Size(640, 426) };

                using var image = Image.Load(file.OpenReadStream());
                image.Mutate(x => x.Resize(resizeOptions));
                await image.SaveAsJpegAsync(saveLocation, cancellationToken: token);

                if(!string.IsNullOrWhiteSpace(recipe.Image))
                {
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", recipe.Image));
                }
                recipe.Image = filename;
                await service.UpdateAsync(recipe, token);

                return Results.Ok(recipe.Image);
            });
    }
}
