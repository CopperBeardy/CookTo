using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Server.Modules.Categories.Handlers;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Tests.Fakes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        var response = await Post.Handle(fakeCategory, categoryServiceMock.Object, new CancellationToken());

        //Assert
        Assert.NotNull(response);
        Assert.IsAssignableFrom<Category>(response);
        Assert.Equal(fakeCategory.Name, response.Name);
    }
}
