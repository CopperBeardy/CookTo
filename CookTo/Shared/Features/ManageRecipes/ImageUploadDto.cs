namespace CookTo.Shared.Features.ManageRecipes;

public class ImageUploadDto
{
    public string RecipeId { get; set; }

    public byte[] Image { get; set; }
}
