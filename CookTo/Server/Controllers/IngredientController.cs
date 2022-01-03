using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
	readonly ILogger<IngredientController> _logger;
	readonly IIngredientService _ingredientService;
	public IngredientController(IIngredientService ingredientService, ILogger<IngredientController> logger)
	{
		_ingredientService = ingredientService;
		_logger = logger;
	}

	[HttpGet]
	public async Task<ActionResult<List<Ingredient>>> GetAll()
	{
		try
		{
			var result = await _ingredientService.GetAllAsync();
			return Ok(result);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, $"get all", "");
			return NotFound();
		}
	}

	[HttpGet("id")]
	public async Task<ActionResult<Ingredient>> GetById(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return BadRequest();
		}

		try
		{
			var result = await _ingredientService.GetByIdAsync(id);
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
			await _ingredientService.DeleteAsync(id);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "delete", id);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Create([FromBody]Ingredient ingredient)
	{
		ingredient.CheckRules();
		if (ingredient.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			await _ingredientService.CreateAsync(ingredient);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "insert", ingredient);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Update([FromBody] Ingredient ingredient)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest();
		}

		try
		{
			await _ingredientService.UpdateAsync(ingredient);
			return Ok(true);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "update", ingredient);
			return NotFound();
		}
	}
}