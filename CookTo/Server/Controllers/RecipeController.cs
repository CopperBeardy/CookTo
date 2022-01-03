using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
	readonly ILogger<RecipeController> _logger;
	readonly IRecipeService _recipeService;
	public RecipeController(IRecipeService recipeService, ILogger<RecipeController> logger)
	{
		_recipeService = recipeService;
		_logger = logger;
	}

	[HttpGet]
	public async Task<ActionResult<List<Recipe>>> GetAll()
	{
		try
		{
			var result = await _recipeService.GetAllAsync();
			return Ok(result);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "get all", "");
			return NotFound();
		}
	}

	[HttpGet("id")]
	public async Task<ActionResult<Recipe>> GetById(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return BadRequest();
		}

		try
		{
			var result = await _recipeService.GetByIdAsync(id);
			return Ok(result);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "get by Id", id);
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
			await _recipeService.DeleteAsync(id);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "delete", id);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Create([FromBody] Recipe recipe)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		try
		{
			await _recipeService.CreateAsync(recipe);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "insert", recipe);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Update([FromBody] Recipe recipe)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		try
		{
			await _recipeService.UpdateAsync(recipe);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "update", recipe);
			return NotFound();
		}
	}
}