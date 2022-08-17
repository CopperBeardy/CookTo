using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Tests.Fakes;
using Xunit;

namespace CookTo.Tests.CookToServerTests.Helpers;

public class TagHelperTests
{
    [Fact]
    public void GenerateTags_with_Valid_Values()
    {
        //arrange
        var model = new  RecipeFaker().Generate();

        //act
        var result = TagHelper.GenerateTags(model.Category, model.Cuisine, model.ShoppingItems);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.Contains(model.Category.Name, result);
        Assert.Contains(model.Cuisine.Name, result);
        foreach(var item in model.ShoppingItems)
        {
            Assert.Contains(item.Ingredient.Name, result);
        }
    }
}
