using CookTo.Shared.Models.ManageCuisines;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class CuisineController : MFControllerBase<Cuisine>
{
    MongoRepository<Cuisine> repository;

    public CuisineController(MongoRepository<Cuisine> _repository) : base(_repository) { repository = _repository; }
}
