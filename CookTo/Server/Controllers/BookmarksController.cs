using CookTo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CookTo.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BookmarksController : ControllerBase
{
	readonly ILogger<BookmarksController> logger;
	readonly IBookmarksService bookmarksService;
	public BookmarksController(IBookmarksService bookmarkService, ILogger<BookmarksController> logger)
	{
		this.bookmarksService = bookmarkService;
		this.logger = logger;
	}

	[HttpGet]
	public async Task<ActionResult<List<Bookmarks>>> GetAll()
	{
		try
		{
			var result = await bookmarksService.GetAllAsync();
			return Ok(result);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "get all", "");
			return NotFound();
		}
	}

	[HttpGet("id")]
	public async Task<ActionResult<Bookmarks>> GetByUserId(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return BadRequest();
		}

		try
		{
			var result = await bookmarksService.GetByUserIdAsync(id);
			return Ok(result);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "get by user Id",  id);
			return NotFound();
		}
	}



	[HttpDelete("id")]
	public async Task<ActionResult<bool>> Delete(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return BadRequest();
		}

		try
		{
			await bookmarksService.DeleteAsync(id);
			return Ok(true);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "delete",  id);
			return NotFound();
		}
	}
	[HttpPut]
	public async Task<ActionResult<Bookmarks>> Create([FromBody] Bookmarks bookmarks)
	{
		bookmarks.CheckRules();
		if (bookmarks.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			await bookmarksService.CreateAsync(bookmarks);
			return Ok(bookmarks);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "insert", bookmarks);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<Bookmarks>> Update([FromBody] Bookmarks bookmarks)
	{
		 bookmarks.CheckRules();
		if (bookmarks.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			await bookmarksService.UpdateAsync(bookmarks);
			return Ok(bookmarks);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "error occured during update", bookmarks);
			return NotFound();
		}
	}
}
