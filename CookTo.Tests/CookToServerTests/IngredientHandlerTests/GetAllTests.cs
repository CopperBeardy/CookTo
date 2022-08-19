using Bogus;
using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.Server.Modules.Ingredients;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Tests.Fakes;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using NuGet.Frameworks;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace CookTo.Tests.CookToServerTests.IngredientHandlerTests;

public class GetAllTests
{
    [Fact]
    public async void Get_All_Ingredients_Existing_IngredientDocuments_Success()
    {
        //Arrange
        var fakes = new IngredientDocumentFaker().GenerateBetween(1, 4);

        var ingredientServiceMock = new Mock<IIngredientService>();
        ingredientServiceMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(fakes);


        //Act
        var response = await IngredientModule.GetAllIngredients(ingredientServiceMock.Object, new CancellationToken());

        //Assert
        var returnItems = Assert.IsType<Ok<List<Ingredient>>>(response).Value;
        Assert.Equal(fakes.Count, returnItems.Count);
    }
}
