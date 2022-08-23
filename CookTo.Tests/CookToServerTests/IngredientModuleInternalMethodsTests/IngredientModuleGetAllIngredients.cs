using AutoMapper;
using Bogus;
using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.Server.Modules.Ingredients;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Tests.Fakes;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace CookTo.Tests.CookToServerTests.IngredientModuleInternalMethodsTests;

public class IngredientModuleGetAllIngredients
{
    [Fact]
    public async void Returns_ListOfIngredient_GivenService_FindsExistingIngredientDocuments()
    {
        //Arrange
        var fakes = new IngredientDocumentFaker().GenerateBetween(1, 4);
        var mapperMock = new Mock<IMapper>();

        var ingredientServiceMock = new Mock<IIngredientService>();
        ingredientServiceMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(fakes);
        var request = new IngredientModule.Request(ingredientServiceMock.Object, mapperMock.Object, new CancellationToken());


        //Act
        var response = await IngredientModule.GetAllIngredients(request);

        //Assert
        var returnItems = Assert.IsType<Ok<List<Ingredient>>>(response).Value;
        Assert.Equal(fakes.Count, returnItems.Count);
    }
}
