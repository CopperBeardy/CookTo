
using Azure.Core;
using CookTo.Server.Repositories;
using CookTo.Shared.Models;
using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;
using CookTo.Shared.Models.ManageRecipes;

using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class HighlightedRecipeController : ControllerBase
{
    IHighlightedRecipeRepository repository;
    public HighlightedRecipeController(IHighlightedRecipeRepository _repository) { repository = _repository; }

    [HttpGet]
    public async Task<IResult> Get()
    {
        var recipe = await repository.Get();

        var highlighted = new HighlightedRecipe()
        {
            Id = recipe.Id,
            Category = new Category { Id = recipe.Id, Name = recipe.Category.Name },
            Title = recipe.Title,
            Cuisine = new Cuisine { Id = recipe.Cuisine.Id, Name = recipe.Cuisine.Name },
            Image = recipe.Image,
            Creator = recipe.Creator,
            AddedBy = recipe.AddedBy,
            PrepTime = recipe.PrepTime,
            CookTime = recipe.CookTime,
            Description = recipe.Description,
            Dietaries = recipe.Dietaries,
            ShoppingList = recipe.ShoppingList,
            Tags = recipe.Tags
        };

        return TypedResults.Ok(highlighted);
    }
}
