using Bogus;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Server.Modules.Categories.Handlers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Tests.Fakes;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        var response = await GetAll.Handle(categoryServiceMock.Object, new CancellationToken());

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
        var response = await GetAll.Handle(categoryServiceMock.Object, new CancellationToken());

        //Assert
        Assert.NotNull(response);
        Assert.IsAssignableFrom<List<Category>>(response);
        Assert.Equal(0, response.Count);
    }

    [Fact]
    public async Task PostCategory()
    {
        await using var app = new WebApplicationFactory<Program>();

        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync($"/api/{EndpointTemplate.CATEGORY}", new CategoryFaker().Generate());
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
