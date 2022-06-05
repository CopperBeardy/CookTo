namespace CookTo.Shared.Features.ManageRecipes;

public class ImageUpload
{
    public string RecipeId { get; set; } = string.Empty;

    public byte[] Image { get; set; }   =  new byte[0];
}
