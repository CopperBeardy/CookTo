using CookTo.Shared.Models.ManageIngredients;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class IngredientController : MFControllerBase<Ingredient>
{
    MongoRepository<Ingredient> repository;

    public IngredientController(MongoRepository<Ingredient> _repository) : base(_repository)
    { repository = _repository; }
}
