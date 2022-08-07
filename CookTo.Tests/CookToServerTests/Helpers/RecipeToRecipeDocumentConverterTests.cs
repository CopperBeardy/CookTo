using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Tests.ModelCreators;
using Xunit;

namespace CookTo.Tests.CookToServerTests.Helpers;

public class RecipeToRecipeDocumentConverterTests
{
    [Fact]
    public void Convert_Recipe_To_RecipeDocument_With_Valid_InputModel()
    {
        //Arrange
        var input = RecipeDocumentCreators.ValidModel();

        //Act 
        var result = RecipeDocumentToRecipeConverter.Convert(input);
        Assert.NotNull(result);
        Assert.IsType<Recipe>(result);
    }
}
