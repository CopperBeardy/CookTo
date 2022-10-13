using CookTo.Shared.Models;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace CookTo.Server.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
//[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
public abstract class MFControllerBase<TEntity> : ControllerBase where TEntity : BaseEntity
{
    private MongoRepository<TEntity> repository;

    public MFControllerBase(MongoRepository<TEntity> repository) { this.repository = repository; }

    [HttpGet]
    [AllowAnonymous]

    public virtual async Task<IResult> Get()
    {
        try
        {
            var result = await repository.GetAllAsync();
            return TypedResults.Ok(result);
        } catch(Exception ex)
        {
            return TypedResults.NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(string id)
    {
        try
        {
            var result = await repository.GetByIdAsync(id);
            return TypedResults.Ok(result);
        } catch(Exception ex)
        {
            return TypedResults.NotFound();
            throw;
        }
    }

    [HttpPost]
    public virtual  async Task<IResult> Create([FromBody] TEntity entity)
    {
        try
        {
            await repository.Insert(entity);
            return TypedResults.Ok(entity);
        } catch(Exception)
        {
            return TypedResults.Problem();
        }
    }

    [HttpPut]
    public virtual async Task<IResult> Update([FromBody] TEntity entity)
    {
        try
        {
            await repository.Insert(entity);
            return TypedResults.Ok(entity);
        } catch(Exception)
        {
            return TypedResults.Problem();
        }
    }

    [HttpDelete("id")]
    public async Task<IResult> Delete(string id)
    {
        try
        {
            var entity = await repository.GetByIdAsync(id);

            if(entity != null)
            {
                await repository.Delete(entity);
                return TypedResults.NoContent();
            } else
            {
                return TypedResults.Problem();
            }
        } catch(Exception ex)
        {
            // log exception here
            var msg = ex.Message;
            return TypedResults.Problem();
        }
    }
}

