using CookTo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CookTo.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BookmarksController : BaseController<Bookmarks>
{
	readonly IBookmarksService bookmarkService;
	readonly ILogger<BookmarksController> logger;

	public BookmarksController(IBookmarksService bookmarkService, ILogger<BookmarksController> logger) : base(
		bookmarkService,
		logger)
	{
		this.logger = logger;
		this.bookmarkService = bookmarkService;
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Bookmarks>> GetByUserIdAsync(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return BadRequest();
		}

		try
		{
			var result = await bookmarkService.GetByUserIdAsync(id);
			return Ok(result);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "get by Id", id);
			return NotFound();
		}
	}
}
