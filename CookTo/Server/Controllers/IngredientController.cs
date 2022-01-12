using CookTo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CookTo.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class IngredientController : BaseController<Ingredient>
{
	public IngredientController(IIngredientService ingredientService, ILogger<IngredientController> logger) : base(
		ingredientService,
		logger)
	{
	}
}