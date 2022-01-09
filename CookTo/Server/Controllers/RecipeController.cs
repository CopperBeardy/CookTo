using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
	readonly ILogger<RecipeController> logger;
	readonly IRecipeService recipeService;
	public RecipeController(IRecipeService recipeService, ILogger<RecipeController> logger)
	{
		this.recipeService = recipeService;
		this.logger = logger;
	}

	[HttpGet]
	public async Task<ActionResult<List<Recipe>>> GetAll()
	{
		try
		{
			var result = await recipeService.GetAllAsync();
			return Ok(result);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "get all", "");
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
			var result = await recipeService.GetByIdAsync(id);
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
			await recipeService.DeleteAsync(id);
			return Ok(true);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "delete", id);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Create([FromBody] Recipe recipe)
	{
		recipe.CheckRules();
		if (recipe.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			await recipeService.CreateAsync(recipe);
			return Ok(true);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "insert", recipe);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Update([FromBody] Recipe recipe)
	{
		recipe.CheckRules();
		if (recipe.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			await recipeService.UpdateAsync(recipe);
			return Ok(true);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "update", recipe);
			return NotFound();
		}
	}
}