using CookTo.Shared.Modules.ManageRecipes;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CookTo.Server.Modules.Images.Handlers;

public static  class UploadImage
{
    public static async Task<IResult> Handle(ImageUpload imageUpload, CommonParameters cp)
    {
        var recipe = await cp.RecipeService.GetByIdAsync(imageUpload.RecipeId, cp.CancellationToken);
        if(recipe is null)
            return Results.BadRequest("Recipe does not exist.");

        if(imageUpload.Image.Length == 0)
            return Results.BadRequest("No image found.");

        var filename = $"{Guid.NewGuid()}.jpg";
        var saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

        var resizeOptions = new ResizeOptions { Mode = ResizeMode.Stretch, Size = new Size(640, 426) };

        using var image = Image.Load(imageUpload.Image);
        image.Mutate(x => x.Resize(resizeOptions));
        await image.SaveAsJpegAsync(saveLocation, cp.CancellationToken);

        if(!string.IsNullOrWhiteSpace(recipe.Image))
            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", recipe.Image));

        recipe.Image = filename;
        await cp.RecipeService.UpdateAsync(recipe, cp.CancellationToken);

        return Results.Ok(recipe.Image);
    }
}
