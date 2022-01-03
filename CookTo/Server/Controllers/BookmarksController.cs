using CookTo.Server.Services.Interfaces;


namespace CookTo.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookmarksController : ControllerBase
{
	readonly ILogger<BookmarksController> _logger;
	readonly IBookmarksService _bookmarksService;
	public BookmarksController(IBookmarksService bookmarkService, ILogger<BookmarksController> logger)
	{
		_bookmarksService = bookmarkService;
		_logger = logger;
	}

	[HttpGet]
	public async Task<ActionResult<List<Bookmarks>>> GetAll()
	{
		try
		{
			var result = await _bookmarksService.GetAllAsync();
			return Ok(result);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "get all", "");
			return NotFound();
		}
	}

	[HttpGet("id")]
	public async Task<ActionResult<Bookmarks>> GetById(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return BadRequest();
		}

		try
		{
			var result = await _bookmarksService.GetByIdAsync(id);
			return Ok(result);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "get by Id",  id);
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
			await _bookmarksService.DeleteAsync(id);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "delete",  id);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Create([FromBody] Bookmarks bookmarks)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		try
		{
			await _bookmarksService.CreateAsync(bookmarks);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "insert", bookmarks);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Update([FromBody] Bookmarks bookmarks)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		try
		{
			await _bookmarksService.UpdateAsync(bookmarks);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "error occured during update", bookmarks);
			return NotFound();
		}
	}
}
