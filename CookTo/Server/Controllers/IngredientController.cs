using CookTo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
			_logger.LogError($"error occured getting all entity type: {typeof(Ingredient).Name}", ex);
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
			_logger.LogError($"error occured during get by Id entity type:{typeof(Ingredient).Name}, id : {id}", ex);
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
			_logger.LogError($"error occured during  delete of entity type:{typeof(Ingredient).Name}, id : {id}", ex);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Create([FromBody] Ingredient ingredient)
	{
		if (!ModelState.IsValid)
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
			_logger.LogError($"error occured during  creation of entity type:{typeof(Ingredient).Name}, object : {ingredient.Name} ", ex);
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
				_logger.LogError($"error occured during  creation of entity type:{typeof(Ingredient).Name}, object : {ingredient.Name} ", ex);
				return NotFound();
			}
		}
}