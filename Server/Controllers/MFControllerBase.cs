﻿using CookTo.Shared.Models;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
//[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
public class MFControllerBase<TEntity> : ControllerBase where TEntity : BaseEntity
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
    public virtual async Task<IResult> GetById(string id)
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
    public async Task<IResult> Create([FromBody] TEntity entity)
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

    [HttpPost]
    public async Task<IResult> Update([FromBody] TEntity entity)
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

