using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace CookTo.Server.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
	public class RecipeController : ControllerBase
	{
		static readonly string[] scopeRequiredByApi = new string[] { "APIAccess" };
	}
}
