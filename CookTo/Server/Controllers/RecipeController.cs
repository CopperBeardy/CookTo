using CookTo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
			_logger.LogError($"error occured getting all entity type: {typeof(Recipe).Name}", ex);
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
			_logger.LogError($"error occured during get by Id entity type:{typeof(Recipe).Name}, id : {id}", ex);
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
			_logger.LogError($"error occured during  delete of entity type:{typeof(Recipe).Name}, id : {id}", ex);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Create([FromBody] Recipe Recipe)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		try
		{
			await _recipeService.CreateAsync(Recipe);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError($"error occured during  creation of entity type:{typeof(Recipe).Name}, object : {Recipe.Title} ", ex);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Update([FromBody] Recipe Recipe)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		try
		{
			await _recipeService.UpdateAsync(Recipe);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError($"error occured during  creation of entity type:{typeof(Recipe).Name}, object : {Recipe.Title} ", ex);
			return NotFound();
		}
	}
}