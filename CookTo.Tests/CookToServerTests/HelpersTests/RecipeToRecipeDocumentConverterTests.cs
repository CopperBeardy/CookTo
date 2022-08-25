using CookTo.DataAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Tests.Fakes;
using Xunit;

namespace CookTo.Tests.CookToServerTests.HelpersTests;

public class RecipeToRecipeDocumentConverterTests
{
    [Fact]
    public void Convert_Recipe_To_RecipeDocument_With_Valid_InputModel()
    {
        //Arrange
        var input = new RecipeFaker().Generate();

        //Act 
        var result = RecipeToRecipeDocumentConverter.Convert(input);
        Assert.NotNull(result);
        Assert.IsType<RecipeDocument>(result);
    }
}
