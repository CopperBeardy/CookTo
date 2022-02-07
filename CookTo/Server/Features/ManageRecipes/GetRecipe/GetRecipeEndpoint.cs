using Ardalis.ApiEndpoints;
using AutoMapper;
using CookTo.Server.Documents.RecipeDocument;
using CookTo.Server.Mappings;
using CookTo.Server.Services.Interfaces;
using CookTo.Shared.Features.ManageRecipes.GetRecipes;
using CookTo.Shared.Features.ManageRecipes.Shared;

namespace CookTo.Server.Features.ManageRecipes.GetRecipe;

public class GetRecipeEndpoint : EndpointBaseAsync.WithRequest<string>.WithActionResult<GetRecipeRequest.Response>
{
    private readonly IRecipeService _recipeService;

    private readonly IMapper _mapper;

    public GetRecipeEndpoint(IRecipeService recipeService, IMapper mapper)
    {
        _recipeService = recipeService;
        _mapper = mapper;
    }

    [HttpGet(GetRecipeRequest.RouteTemplate)]
    public override async Task<ActionResult<GetRecipeRequest.Response>> HandleAsync(
        string recipeId,
        CancellationToken cancellationToken = default)
    {
        var recipe = await _recipeService.GetByIdAsync(recipeId, cancellationToken);

        if(recipe is null)
        {
            return BadRequest("Recipe could not be found.");
        }
        var response = new RecipeDto();
        response.Id = recipe.Id;
        response.Title = recipe.Title;
        response.Category = recipe.Category;
        response.Description = recipe.Description;
        response.Image = recipe.Image;
        response.PreparationTime = recipe.PreparationTime;
        response.CookingTime = recipe.CookingTime;
        response.Serves = recipe.Serves;
        response.AuthorId = recipe.AuthorId;
        response.RecipeParts.Clear();
        response.RecipeParts
            .AddRange(
                recipe.RecipeParts
                    .Select(rp => new RecipePart { PartTitle = rp.PartTitle, Items = GetPartIngredients(rp.Items) }));


        response.CookingSteps
            .AddRange(
                recipe.CookingSteps
                    .Select(
                        cs => new CookingStep { OrderNumber = cs.OrderNumber, StepDescription = cs.StepDescription }));

        response.Utensils
            .AddRange(
                recipe.Utensils
                    .Select(ut => new UtensilPart { RequiredAmount = ut.RequiredAmount, UtensilName = ut.UtensilName }));

        response.Tips = recipe.Tips != null ? recipe.Tips : new List<string>();
        return Ok(response);
    }

    private static List<PartIngredient> GetPartIngredients(List<SectionPartIngredient> Items) => Items.Select(
        ing => new PartIngredient
        {
            Amount = (double)ing.Amount,
            Unit = ing.Unit,
            IngredientName = ing.IngredientName,
            AdditionalInformation = ing.AdditionalInformation
        })
        .ToList();
}
