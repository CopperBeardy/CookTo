using CookTo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CookTo.Server.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
	//static readonly string[] scopeRequiredByApi = new string[] { "CookToB2CServer.Access" };
	readonly ILogger<IngredientController> logger;
	readonly IIngredientService ingredientService;
	public IngredientController(IIngredientService ingredientService, ILogger<IngredientController> logger)
	{
		this.ingredientService = ingredientService;
		this.logger = logger;
	}

	[HttpGet]
	public async Task<ActionResult<List<Ingredient>>> GetAll()
	{
		try
		{
			var result = await ingredientService.GetAllAsync();
			return Ok(result);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, $"get all", "");
			return NotFound();
		}
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Ingredient>> GetById(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return BadRequest();
		}

		try
		{
			var result = await ingredientService.GetByIdAsync(id);
			return Ok(result);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "get by Id", id);
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
			 await ingredientService.DeleteAsync(id);
			return Ok(true);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "delete", id);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<Ingredient>> Create([FromBody]Ingredient ingredient)
	{
		ingredient.CheckRules();
		if (ingredient.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			await ingredientService.CreateAsync(ingredient);
			return Ok(ingredient);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "insert", ingredient);
			return NotFound();
		}
	}
	[HttpPut]
	public async Task<ActionResult<Ingredient>> Update([FromBody] Ingredient ingredient)
	{
		ingredient.CheckRules();
		if (ingredient.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			 await ingredientService.UpdateAsync(ingredient);
			return Ok(ingredient);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "update", ingredient);
			return NotFound();
		}
	}
}