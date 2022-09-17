
using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : MFControllerBase<Category>
{
    MongoRepository<Category> repository;
    public CategoryController(MongoRepository<Category> _repository) : base(_repository) { repository = _repository; }
}
