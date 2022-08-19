using Bogus;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Server.Modules.Categories;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Tests.Fakes;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace CookTo.Tests.CookToServerTests.CategoryHandlerTests;

public class GetAllTests
{
    [Fact]
    public async void Get_All_Categories_With_Valid_Data_Success()
    {
        //Arrange
        var categoryServiceMock = new Mock<ICategoryService>();
        var fakes = new CategoryDocumentFaker().GenerateBetween(1, 4).ToList();

        categoryServiceMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(fakes);


        //Act 
        var response = await CategoryModule.GetAllCategories(categoryServiceMock.Object, new CancellationToken());

        //Assert

        var returnedItems = Assert.IsType<Ok<List<Category>>>(response).Value;
        Assert.NotNull(returnedItems);
        Assert.IsAssignableFrom<List<Category>>(returnedItems);
        Assert.Equal(fakes.Count, returnedItems.Count);
    }

    [Fact]
    public async void Get_All_With_No_Data_Success()
    {
        //Arrange
        var categoryServiceMock = new Mock<ICategoryService>();

        categoryServiceMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<CategoryDocument>());

        //Act 
        var response = await CategoryModule.GetAllCategories(categoryServiceMock.Object, new CancellationToken());

        //Assert
        Assert.NotNull(response);
        var returnedItems = Assert.IsType<Ok<List<Category>>>(response).Value;

        Assert.Equal(0, returnedItems.Count);
    }
}
