using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Tests.ModelCreators;
using System;
using Xunit;

namespace CookTo.Tests.CookToServerTests.Helpers;

public class RecipeDocumentToRecipeConverterTests
{
    [Fact]
    public void Convert_RecipeDocument_To_FullRecipe_With_Valid_InputModel()
    {
        //Arrange
        var input = RecipeDocumentCreators.ValidModel();

        //Act 
        var result = RecipeDocumentToRecipeConverter.Convert(input);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<Recipe>(result);
    }

    [Fact]

    public void Convert_RecipeDocument_To_FullRecipe_With_NullValuedModel_InputModel()
    {
        //Arrange
        var input = RecipeDocumentCreators.NulledValuedModel();

        //Act   //Assert
        Exception ex = Assert.Throws<NullReferenceException>(() => RecipeDocumentToRecipeConverter.Convert(input));

        Assert.IsType<NullReferenceException>(ex);
    }
}
