using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.Features.ManageRecipes;

public static class SetEditValues
{
    public static RecipeDto SetValues(RecipeDto recipe)
    {
        var editRecipe = new RecipeDto();

        if (recipe != null)
        {
            editRecipe.Id = recipe.Id;
            editRecipe.Title = recipe.Title;
            editRecipe.Category = recipe.Category;
            editRecipe.Description = recipe.Description;
            editRecipe.Image = recipe.Image;
            editRecipe.PrepTimeFrom = recipe.PrepTimeFrom;
            editRecipe.PrepTimeTo = recipe.PrepTimeTo;
            editRecipe.CookTimeFrom = recipe.CookTimeFrom;
            editRecipe.CookTimeTo = recipe.CookTimeTo;
            editRecipe.Serves = recipe.Serves;
            editRecipe.AuthorId = recipe.AuthorId;
            editRecipe.RecipeParts.Clear();
            editRecipe.RecipeParts
                .AddRange(
                    recipe.RecipeParts
                        .Select(rp => new RecipePart { PartTitle = rp.PartTitle, Items = GetPartIngredients(rp.Items) }));
        }
        editRecipe.CookingSteps.Clear();
        editRecipe.CookingSteps
            .AddRange(
                recipe.CookingSteps
                    .Select(
                        cs => new CookingStep { OrderNumber = cs.OrderNumber, StepDescription = cs.StepDescription }));
        editRecipe.Utensils.Clear();
        editRecipe.Utensils
            .AddRange(
                recipe.Utensils
                    .Select(ut => new UtensilPart { RequiredAmount = ut.RequiredAmount, UtensilName = ut.UtensilName }));

        editRecipe.Tips = recipe.Tips != null ? recipe.Tips : new List<string>();
        return editRecipe;
    }

    private static List<PartIngredient> GetPartIngredients(List<PartIngredient> Items) => Items.Select(
        ing => new PartIngredient
        {
            Amount = ing.Amount,
            Unit = ing.Unit,
            IngredientName = ing.IngredientName,
            AdditionalInformation = ing.AdditionalInformation
        })
        .ToList();
}

