﻿namespace CookTo.Shared.Modules.ManageRecipes;

public class ImageUpload
{
    public string RecipeId { get; set; } = string.Empty;

    public byte[] Image { get; set; } = Array.Empty<byte>();
}
