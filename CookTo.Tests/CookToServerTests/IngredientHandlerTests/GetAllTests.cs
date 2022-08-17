using Bogus;
using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.Server.Modules.Ingredients.Handlers;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Tests.Fakes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
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

        var ingredientServiceMock = new Mock<IIngredientService>();
        ingredientServiceMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new IngredientDocumentFaker().GenerateBetween(1, 4));


        //Act
        var response = await GetAll.Handle(ingredientServiceMock.Object, new CancellationToken());

        //Assert
        var result = Assert.IsAssignableFrom<OkObjectResult>(response);
        var value = Assert.IsAssignableFrom<List<Ingredient>>(result.Value);
        // Assert.NotNull(response);
    }
}
