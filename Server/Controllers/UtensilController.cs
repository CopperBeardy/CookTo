using CookTo.Shared.Models.ManageUtensils;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class UtensilController : MFControllerBase<Utensil>
{
    MongoRepository<Utensil> repository;

    public UtensilController(MongoRepository<Utensil> _repository) : base(_repository) { repository = _repository; }
}
