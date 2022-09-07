namespace CookTo.Shared;

public static class EndpointTemplate
{
    public const string BASE_ENDPOINT = "/api/";
    public const string CATEGORY = "category";
    public const string CATEGORY_GET_REDIRECT = $"{BASE_ENDPOINT}category";
    public const string CUISINE = "cuisine";
    public const string CUISINE_GET_REDIRECT = $"{BASE_ENDPOINT}cuisine";
    public const string UTENSIL = "utensil";
    public const string UTENSIL_GET_REDIRECT = $"{BASE_ENDPOINT}utensil";
    public const string RECIPE = "recipe";
    public const string RECIPE_GET_REDIRECT = $"{BASE_ENDPOINT}recipe";
    public const string HIGHLIGHTED = "highlighted";
    public const string SUMMARY = "summary";
    public const string UPLOADIMAGE = "upload";
    public const string INGREDIENT = "ingredient";
    public const string INGREDIENT_GET_REDIRECT = $"{BASE_ENDPOINT}ingredient";
    public const string TIP = "tip";
    public const string TIP_GET_REDIRECT = $"{BASE_ENDPOINT}tip";
}
