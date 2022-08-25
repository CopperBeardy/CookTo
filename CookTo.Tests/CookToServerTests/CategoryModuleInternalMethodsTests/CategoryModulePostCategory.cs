using AutoMapper;
using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CategoryDocumentAccess.Services;
using CookTo.Server.Modules.Categories;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Tests.Fakes;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CookTo.Tests.CookToServerTests.CategoryModuleInternalMethodsTests;

public class CategoryModulePostCategory
{
    [Fact]
    public async void Return_CreatedResultWithRecipe_WhenNewRecipeDocumentCreatedInDatabase()
    {
        var categoryServiceMock = new Mock<ICategoryService>();
        var fakeCategory = new CategoryFaker().Generate("New");
        var categoryDocument = new CategoryDocument() { Name = fakeCategory.Name };
        var mapperMock = new Mock<IMapper>();

        categoryServiceMock.Setup(x => x.CreateAsync(It.IsAny<CategoryDocument>(), It.IsAny<CancellationToken>()))
            .Callback(async (CategoryDocument categoryDoc, CancellationToken cancellationToken) =>
            {
                categoryDocument.Id = new Guid().ToString();
            });


        var request = new CategoryModule.Request(categoryServiceMock.Object, mapperMock.Object, new CancellationToken());
        //Act
        var response = await CategoryModule.PostCategory(fakeCategory, request);

        //Assert
        Assert.NotNull(response);
        var returnedItem = Assert.IsType<Created<Category>>(response).Value;
        Assert.IsAssignableFrom<Category>(returnedItem);
        Assert.Equal(fakeCategory.Name, returnedItem.Name);
    }
}
