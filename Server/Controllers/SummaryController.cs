using CookTo.Server.Repositories;
using CookTo.Shared.Models;
using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookTo.Server.Controllers;


[Route("[controller]")]
[ApiController]
public class SummaryController : ControllerBase
{
    IRecipeSummaryRepository repository;
    public SummaryController(IRecipeSummaryRepository _repository) { repository = _repository; }


    [HttpGet("{amount}")]
    public async Task<IResult> Get(string amount)
    {
        var response = await repository.GetCountAsync(int.Parse(amount));
        var summaries = new List<RecipeSummary>();
        if(response is not null || response.Any())

            summaries.AddRange(response.Select(recipe => new RecipeSummary
                {
                    Id = recipe.Id,
                    Category = new Category { Id = recipe.Id, Name = recipe.Category.Name },
                    Title = recipe.Title,
                    Cuisine = new Cuisine { Id = recipe.Cuisine.Id, Name = recipe.Cuisine.Name },
                    Image = recipe.Image,
                    Creator = recipe.Creator,
                    AddedBy = recipe.AddedBy,
                    Dietaries = recipe.Dietaries,
                    ShoppingList = recipe.ShoppingList,
                    Tags = recipe.Tags
                }));
        return TypedResults.Ok(summaries);
    }
}
