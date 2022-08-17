using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Shared.Modules.ManageRecipes;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CookTo.Server.Modules.Images.Handlers;

public static class UploadImage
{
    public static async Task<IResult> Handle(ImageUpload imageUpload, IRecipeService service, CancellationToken cancellationToken)
    {
        var recipe = await service.GetByIdAsync(imageUpload.RecipeId, cancellationToken);
        if(recipe is null)
            return Results.BadRequest("Recipe does not exist.");

        if(imageUpload.Image.Length == 0)
            return Results.BadRequest("No image found.");

        var filename = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

        var resizeOptions = new ResizeOptions { Mode = ResizeMode.Stretch, Size = new Size(640, 426) };

        using var image = Image.Load(imageUpload.Image);
        image.Mutate(x => x.Resize(resizeOptions));
        await image.SaveAsJpegAsync(saveLocation, cancellationToken);

        if(!string.IsNullOrWhiteSpace(recipe.Image))
            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", recipe.Image));

        recipe.Image = filename;
        await service.UpdateAsync(recipe, cancellationToken);

        return Results.Ok(recipe.Image);
    }
}
