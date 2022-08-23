using AutoMapper;
using CookTo.DataAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Tests.Fakes;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CookTo.Tests.CookToServerTests.RecipeModuleInternalMethodsTests;

public class RecipeModuleGetRecipe
{
    [Fact]
    public async void Returns_Recipe_WithAllFieldsPopulated_GivenService_FindsValidRecipeDocument()
    {
        // Arrange
        var recipeFake = new RecipeDocumentFaker().Generate();
        var recipeServiceMock = new Mock<IRecipeService>();
        var mapperMock = new Mock<IMapper>();

        recipeServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(recipeFake);
        var request = new RecipeModule.Request(recipeServiceMock.Object, mapperMock.Object, new CancellationToken());


        // Act
        var response = await RecipeModule.GetByIdRecipe(new Guid().ToString(), request);

        // Assert
        Assert.NotNull(response);
        var result = Assert.IsType<Ok<Recipe>>(response).Value;
        Assert.IsAssignableFrom<Recipe>(result);
    }

    [Fact]
    public async void Returns_NotFoundResult_WhenInvalidId()
    {
        // Arrange

        var recipeServiceMock = new Mock<IRecipeService>();
        var mapperMock = new Mock<IMapper>();

        recipeServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((RecipeDocument)null);
        var request = new RecipeModule.Request(recipeServiceMock.Object, mapperMock.Object, new CancellationToken());


        // Act
        var response = await RecipeModule.GetByIdRecipe(new Guid().ToString(), request);

        // Assert
        Assert.NotNull(response);
        Assert.IsType<NotFound<string>>(response);
    }

    //dietaries populate and empty
    //cooking step with and without ingredients
    //stepingredient with and without quantity and measure 
    //utensil must have atleast 1 item 
    //shopping list must have atleast 1 item
    //shopping list items with and without - quantity, measure or additional information
}
