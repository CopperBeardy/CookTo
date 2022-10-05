using CookTo.Server.Helpers;
using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;
using CookTo.Shared.Models.ManageIngredients;
using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Tests;

public class RecipeHelperTests
{
    Recipe recipe;

    public RecipeHelperTests()
    {
        recipe = new Recipe();
        recipe.RecipeParts = new List<RecipePart>()
        {
                new RecipePart()
                {
                    RecipePartIngredients =
                        new List<RecipePartIngredient>()
                    {
                        new RecipePartIngredient()
                        {
                            Quantity = "1",
                            Measure = Shared.Enums.MeasureUnit.g,
                            Ingredient = new Ingredient { Id = "as", Name = "flour" },
                            AdditionalInformation = string.Empty
                        },
                        new RecipePartIngredient()
                        {
                            Quantity = "2",
                            Measure = Shared.Enums.MeasureUnit.g,
                            Ingredient = new Ingredient { Id = "a2", Name = "sugar" },
                            AdditionalInformation = string.Empty
                        } }
                },
                new RecipePart()
                {
                    RecipePartIngredients =
                        new List<RecipePartIngredient>()
                    {
                        new RecipePartIngredient()
                        {
                            Quantity = "1",
                            Measure = Shared.Enums.MeasureUnit.g,
                            Ingredient = new Ingredient { Id = "as", Name = "flour" },
                            AdditionalInformation = string.Empty
                        },
                        new RecipePartIngredient()
                        {
                            Quantity = "a",
                            Measure = Shared.Enums.MeasureUnit.g,
                            Ingredient = new Ingredient { Id = "a2", Name = "sugar" },
                            AdditionalInformation = string.Empty
                        },
        }
                } };
    }


[Fact]z

    public async Task AggregateIngredients()
    {
        recipe.Cuisine = new Cuisine() { Id = "dasd", Name = "British" };
        recipe.Category = new Category() { Id = "dasda", Name = "Cake" };
        var result = await RecipeHelper.CompleteRecipe(recipe);
        Assert.NotNull(result);
    }
}
