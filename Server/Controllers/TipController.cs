
using CookTo.Shared.Models.ManageTips;
using CookTo.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookTo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class TipController : MFControllerBase<Tip>
{
    MongoRepository<Tip> repository;

    public TipController(MongoRepository<Tip> _repository) : base(_repository) { repository = _repository; }
}
