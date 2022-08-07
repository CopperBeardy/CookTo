using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Tests.ModelCreators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CookTo.Tests.CookToServerTests.Helpers;

public class TagHelperTests
{
    [Fact]
    public void GenerateTags_with_Valid_Values()
    {
        //arrange
        var model = RecipeCreators.ValidModel();

        //act
        var result = TagHelper.GenerateTags(model.Category, model.Cuisine, model.ShoppingItems);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.Contains(model.Category.Text, result);
        Assert.Contains(model.Cuisine.Text, result);
        foreach(var item in model.ShoppingItems)
        {
            Assert.Contains(item.Ingredient.Text, result);
        }
    }
}
