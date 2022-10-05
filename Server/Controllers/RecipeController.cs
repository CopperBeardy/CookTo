using CookTo.Server.Helpers;
using CookTo.Shared.Models.ManageRecipes;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    MongoRepository<Recipe> _repository;


    public RecipeController(MongoRepository<Recipe> repository) { _repository = repository; }


    [HttpGet]
    [AllowAnonymous]
    public virtual async Task<IResult> Get()
    {
        try
        {
            var result = await _repository.GetAllAsync();
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
            var result = await _repository.GetByIdAsync(id);
            return TypedResults.Ok(result);
        } catch(Exception ex)
        {
            return TypedResults.NotFound();
            throw;
        }
    }

    [HttpPost]
    public virtual async Task<IResult> Create([FromBody] Recipe recipe)
    {
        try
        {
            recipe.AddedBy = HttpContext.User.Claims.First(t => t.Type == ClaimConstants.Name).Value.ToString();
            recipe = await RecipeHelper.CompleteRecipe(recipe);
            await _repository.Insert(recipe);
            return TypedResults.Ok(recipe);
        } catch(Exception)
        {
            return TypedResults.Problem();
        }
    }

    [HttpPut]
    public virtual async Task<IResult> Update([FromBody] Recipe recipe)
    {
        try
        {
            recipe.Tags = string.Empty;
            recipe.ShoppingList.Clear();
            recipe = await RecipeHelper.CompleteRecipe(recipe);
            await _repository.Update(recipe);
            return TypedResults.Ok(recipe);
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
            var entity = await _repository.GetByIdAsync(id);

            if(entity != null)
            {
                await _repository.Delete(entity);
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
