﻿using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
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

	[HttpGet("id")]
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

	[HttpGet("name")]
	public async Task<ActionResult<Ingredient>> GetByName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return BadRequest();
		}

		try
		{
			var result = await ingredientService.GetByNameAsync(name);
			return Ok(result);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "get by name", name);
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
	public async Task<ActionResult<bool>> Create([FromBody]Ingredient ingredient)
	{
		ingredient.CheckRules();
		if (ingredient.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			await ingredientService.CreateAsync(ingredient);
			return Ok(true);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "insert", ingredient);
			return NotFound();
		}
	}
	[HttpPost]
	public async Task<ActionResult<bool>> Update([FromBody] Ingredient ingredient)
	{
		ingredient.CheckRules();
		if (ingredient.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			 await ingredientService.UpdateAsync(ingredient);
			return Ok(true);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "update", ingredient);
			return NotFound();
		}
	}
}