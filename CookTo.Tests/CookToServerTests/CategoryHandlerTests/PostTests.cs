using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Server.Modules.Categories;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Tests.Fakes;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CookTo.Tests.CookToServerTests.CategoryHandlerTests;

public class PostTests
{
    [Fact]
    public async void Post_With_Valid_Category_Success()
    {
        var categoryServiceMock = new Mock<ICategoryService>();
        var fakeCategory = new CategoryFaker().Generate("New");
        var categoryDocument = new CategoryDocument() { Name = fakeCategory.Name };


        categoryServiceMock.Setup(x => x.CreateAsync(It.IsAny<CategoryDocument>(), It.IsAny<CancellationToken>()))
            .Callback(async (CategoryDocument categoryDoc, CancellationToken cancellationToken) =>
            {
                categoryDocument.Id = new Guid().ToString();
            });

        //Act
        var response = await CategoryModule.PostCategory(fakeCategory, categoryServiceMock.Object, new CancellationToken());

        //Assert
        Assert.NotNull(response);
        Assert.IsAssignableFrom<Category>(response);
        Assert.Equal(fakeCategory.Name, response.Name);
    }
}
