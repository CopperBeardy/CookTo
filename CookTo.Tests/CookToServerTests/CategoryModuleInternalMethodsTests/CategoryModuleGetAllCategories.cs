using AutoMapper;
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

namespace CookTo.Tests.CookToServerTests.CategoryModuleInternalMethodsTests;

public class CategoryModuleGetAllCategories
{
    [Fact]
    public async void Return_ListOfCategory_GivenService_FindsExistingCategoryDocuments()
    {
        //    //Arrange
        //    var categoryServiceMock = new Mock<ICategoryService>();
        //    var fakes = new CategoryDocumentFaker().GenerateBetween(1, 4).ToList();
        //    var mapperMock = new Mock<IMapper>();

        //    categoryServiceMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(fakes);

        //    var request = new CategoryModule.Request(categoryServiceMock.Object, mapperMock.Object, new CancellationToken());

        //    //Act 
    //    var response = await CategoryModule.GetAllCategories(request);

        //    //Assert

        //    var returnedItems = Assert.IsType<Ok<List<Category>>>(response).Value;
    //    Assert.NotNull(returnedItems);
    //    Assert.IsAssignableFrom<List<Category>>(returnedItems);
    //    Assert.Equal(fakes.Count, returnedItems.Count);
    }

    [Fact]
    public async void Return_EmptyListOfCategory_GivenService_FindsNoCategoryDocuments()
    {
        ////Arrange
        //var categoryServiceMock = new Mock<ICategoryService>();
        //var mapperMock = new Mock<IMapper>();

        //categoryServiceMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
        //    .ReturnsAsync(new List<CategoryDocument>());
        //var request = new CategoryModule.Request(categoryServiceMock.Object, mapperMock.Object, new CancellationToken());

        ////Act 
        //var response = await CategoryModule.GetAllCategories(request);
        ////Assert
        //Assert.NotNull(response);
        //var returnedItems = Assert.IsType<Ok<List<Category>>>(response).Value;
        //Assert.Empty(returnedItems);
    }
}
