using CookTo.Server.Controllers.Interfaces;
using CookTo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CookTo.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TEntity> : ControllerBase, IBaseController<TEntity> where TEntity : BaseEntity
{
	//static readonly string[] scopeRequiredByApi = new string[] { "CookToB2CServer.Access" };
	readonly ILogger logger;
	readonly IBaseService<TEntity> service;

	public BaseController(IBaseService<TEntity> service, ILogger logger)
	{
		this.service = service;
		this.logger = logger;
	}

	[HttpGet]
	public virtual async Task<ActionResult<List<TEntity>>> GetAllAsync()
	{
		try
		{
			var result = await service.GetAllAsync();
			return Ok(result);
		} catch(Exception ex)
		{
			logger.LogError(ex, $"get all", string.Empty);
			return NotFound();
		}
	}

	[HttpGet("{id}")]
	public virtual async Task<ActionResult<TEntity>> GetByIdAsync(string id)
	{
		if(string.IsNullOrEmpty(id))
		{
			return BadRequest();
		}

		try
		{
			var result = await service.GetByIdAsync(id);
			return Ok(result);
		} catch(Exception ex)
		{
			logger.LogError(ex, "get by Id", id);
			return NotFound();
		}
	}


	[HttpDelete("id")]
	public virtual async Task<ActionResult<bool>> DeleteAsync(string id)
	{
		if(string.IsNullOrEmpty(id))
		{
			return BadRequest();
		}

		try
		{
			await service.DeleteAsync(id);
			return Ok(true);
		} catch(Exception ex)
		{
			logger.LogError(ex, "delete", id);
			return NotFound();
		}
	}

	[HttpPost]
	public virtual async Task<ActionResult<TEntity>> CreateAsync([FromBody] TEntity entity)
	{
		entity.CheckRules();
		if(entity.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			await service.CreateAsync(entity);
			return Ok(entity);
		} catch(Exception ex)
		{
			logger.LogError(ex, "insert", entity);
			return NotFound();
		}
	}

	[HttpPut]
	public virtual async Task<ActionResult<TEntity>> UpdateAsync([FromBody] TEntity entity)
	{
		entity.CheckRules();
		if(entity.HasErrors())
		{
			return BadRequest();
		}

		try
		{
			await service.UpdateAsync(entity);
			return Ok(entity);
		} catch(Exception ex)
		{
			logger.LogError(ex, "update", entity);
			return NotFound();
		}
	}
}
