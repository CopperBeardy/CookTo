
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Tests.Fakes;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace CookTo.Tests.CookToServerTests.RecipeHandlerTests;

public class GetCompleteRecipeTests
{
    [Fact]
    public async void Get_Recipe_With_All_Values_Populate_Success()
    {
        // Arrange
        var recipeFake = new RecipeDocumentFaker().Generate();
        var recipeServiceMock = new Mock<IRecipeService>();

        recipeServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(recipeFake);
        // Act
        var response = await GetById.Handle(new Guid().ToString(), recipeServiceMock.Object, new CancellationToken());

        // Assert
        Assert.NotNull(response);

        Assert.IsAssignableFrom<Recipe>(response);
    }

    [Fact]
    public async void Get_Recipe_With_No_relate_db_object_failure()
    {
        // Arrange

        var recipeServiceMock = new Mock<IRecipeService>();

        recipeServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((RecipeDocument)null);
        // Act
        var response = await GetById.Handle(new Guid().ToString(), recipeServiceMock.Object, new CancellationToken());

        // Assert
        Assert.Null(response);
    }

    //dietaries populate and empty
    //cooking step with and without ingredients
    //stepingredient with and without quantity and measure 
    //utensil must have atleast 1 item 
    //shopping list must have atleast 1 item
    //shopping list items with and without - quantity, measure or additional information
}
