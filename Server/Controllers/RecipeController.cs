using CookTo.Shared.Models.ManageRecipes;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class RecipeController : MFControllerBase<Recipe>
{
    MongoRepository<Recipe> repository;
    public RecipeController(MongoRepository<Recipe> _repository) : base(_repository) { repository = _repository; }
}
