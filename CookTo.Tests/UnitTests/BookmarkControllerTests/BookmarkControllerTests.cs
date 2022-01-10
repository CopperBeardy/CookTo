﻿using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.BookmarkControllerTests;

public class BookmarkControllerTests : BookmarksFixture
{
	[Fact]
	public async Task InsertBookmarks_ValidModel_Success()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Bookmarks>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Create(_bookmarks);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Bookmarks>()), Times.Once());
	}

	[Fact]
	public async Task InsertBookmarks_InValidModel_Failure()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Name", "Name is required");

		var result = await SUT.Create(new Bookmarks());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Bookmarks>()), Times.Never());
	}

	[Fact]
	public async Task InsertBookmarks_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Bookmarks>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.Create(_bookmarks);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	
	}

	[Fact]
	public async Task Delete_Bookmarks_Success()
	{
		_mockService.Setup(g => g.DeleteAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Delete("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.DeleteAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task Delete_Bookmarks_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.DeleteAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.Delete("1111a1111b1111c1111d1111");
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task Delete_Bookmarks_InvalidId_Success(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.Delete(id);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

	[Fact]
	public async Task GetByUserID_Bookmarks_Success()
	{
		_mockService.Setup(g => g.GetByUserIdAsync(It.IsAny<string>())).ReturnsAsync(_bookmarks);

		Assert.NotNull(SUT);

		var result = await SUT.GetByUserId("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as Bookmarks;
		Assert.Equal(_bookmarks.UserId, obj.UserId);

		_mockService.Verify(g => g.GetByUserIdAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task GetByUserId_Bookmarks_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.GetByUserIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetByUserId("1111a1111b1111c1111d1111");
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task GetByID_Bookmarks_InvalidId_Success(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.GetByUserId(id);
		var badRequesstResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequesstResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}
	[Fact]
	public async Task UpdateBookmarks_ValidModel_Success()
	{
		var Bookmarked = new Bookmarked()
		{
			RecipeId = new ObjectId("1111a1111b1111c1111d1111"),
			Title = "Cheddar Cheese"
		};
		_bookmarks.BookmarkedRecipes.Add(Bookmarked);
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Bookmarks>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Update(_bookmarks);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Bookmarks>()), Times.Once());
	}

	[Fact]
	public async Task UpdateBookmarks_InValidModel_Failure()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("userid", "userid is required");

		var result = await SUT.Update(new Bookmarks());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Bookmarks>()), Times.Never());
	}

	[Fact]
	public async Task UpdateBookmarks_ExceptionThrown_Failure()
	{
		var Bookmarked = new Bookmarked()
		{
			RecipeId = new ObjectId("1111a1111b1111c1111d1111"),
			Title = "Cheddar Cheese"
		};
		_bookmarks.BookmarkedRecipes.Add(Bookmarked);

		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Bookmarks>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.Update(_bookmarks);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);


	}


}