using Bogus;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Server.Modules.Categories;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Tests.Fakes;
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
        Assert.NotNull(response);
        Assert.IsAssignableFrom<List<Category>>(response);
        Assert.Equal(fakes.Count, response.Count);
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
        Assert.IsAssignableFrom<List<Category>>(response);
        Assert.Equal(0, response.Count);
    }
}
