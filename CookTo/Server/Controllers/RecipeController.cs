using CookTo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CookTo.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RecipeController : BaseController<Recipe>
{
	public RecipeController(IRecipeService recipeService, ILogger<RecipeController> logger) : base(
		recipeService,
		logger)
	{
	}
}