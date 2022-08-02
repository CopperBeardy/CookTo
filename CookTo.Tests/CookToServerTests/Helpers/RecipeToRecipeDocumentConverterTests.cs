using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Server.Modules.Utensils.Core;
using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Tests.ModelCreators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
