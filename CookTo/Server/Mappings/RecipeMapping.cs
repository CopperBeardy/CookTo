using CookTo.Server.Documents.RecipeDocument;
using CookTo.Shared.Features.ManageRecipes.Shared;

namespace CookTo.Server.Mappings;

public static class RecipeMapping
{
    public static Recipe FromDtoToRecipe(RecipeDto obj)
    {
        Recipe recipe = new Recipe()
        {
            Id = obj.Id,
            Title = obj.Title,
            Category = obj.Category,
            Description = obj.Description,
            Image = obj.Image,
            PreparationTime = obj.PreparationTime,
            CookingTime = obj.CookingTime,
            Serves = obj.Serves,
            AuthorId = obj.AuthorId
        };
        foreach(var recipePart in obj.RecipeParts)
        {
            var part = new SectionRecipePart();
            part.PartTitle = recipePart.PartTitle;
            foreach(var pi in recipePart.Items)
            {
                part.Items
                    .Add(
                        new SectionPartIngredient()
                        {
                            Amount = pi.Amount,
                            Unit = pi.Unit,
                            IngredientName = pi.IngredientName,
                            AdditionalInformation = pi.AdditionalInformation
                        });
            }
            ;
            recipe.RecipeParts.Add(part);
        }
        recipe.CookingSteps
            .AddRange(
                obj.CookingSteps
                    .Select(
                        cs => new SectionCookingStep()
                            {
                                OrderNumber = cs.OrderNumber,
                                StepDescription = cs.StepDescription
                            }));
        recipe.Utensils
            .AddRange(
                obj.Utensils
                    .Select(
                        ut => new SectionUtensilPart()
                            {
                                RequiredAmount = ut.RequiredAmount,
                                UtensilName = ut.UtensilName
                            }));
        recipe.Tips = obj.Tips != null ? obj.Tips : new List<string>();
        return recipe;
    }

    public static RecipeDto FromRecipeToDto(Recipe obj)
    {
        RecipeDto recipe = new RecipeDto()
        {
            Id = obj.Id,
            Title = obj.Title,
            Category = obj.Category,
            Description = obj.Description,
            Image = obj.Image,
            PreparationTime = obj.PreparationTime,
            CookingTime = obj.CookingTime,
            Serves = obj.Serves,
            AuthorId = obj.AuthorId
        };
        foreach(var recipePart in obj.RecipeParts)
        {
            var part = new RecipePart();
            part.PartTitle = recipePart.PartTitle;
            foreach(var pi in recipePart.Items)
            {
                part.Items
                    .Add(
                        new PartIngredient()
                        {
                            Amount = (double)pi.Amount,
                            Unit = pi.Unit,
                            IngredientName = pi.IngredientName,
                            AdditionalInformation = pi.AdditionalInformation
                        });
            }
            ;
            recipe.RecipeParts.Add(part);
        }
        recipe.CookingSteps
            .AddRange(
                obj.CookingSteps
                    .Select(
                        cs => new CookingStep() { OrderNumber = cs.OrderNumber, StepDescription = cs.StepDescription }));
        recipe.Utensils
            .AddRange(
                obj.Utensils
                    .Select(
                        ut => new UtensilPart() { RequiredAmount = ut.RequiredAmount, UtensilName = ut.UtensilName }));
        recipe.Tips = obj.Tips != null ? obj.Tips : new List<string>();
        return recipe;
    }
}