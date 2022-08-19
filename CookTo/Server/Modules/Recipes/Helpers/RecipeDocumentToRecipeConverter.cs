using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.DataAccess.Documents.TipDocumentAccess;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Server.Modules.Recipes.Helpers;

public static class RecipeDocumentToRecipeConverter
{
    public static Recipe Convert(RecipeDocument recipe)
    {
        var fullRecipe = new Recipe()
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Cuisine = new Cuisine { Id = recipe.Cuisine.Id, Name = recipe.Cuisine.Name },
            Category = new Category { Id = recipe.Category.Id, Name = recipe.Category.Name },
            Description = recipe.Description,
            Image = recipe.Image,
            PrepTime = recipe.PrepTime,
            CookTime = recipe.CookTime,
            Serves = recipe.Serves,
            Creator = recipe.Creator,
            AddedBy = recipe.AddedBy,
            Dietaries = recipe.Dietaries,
            Tags = recipe.Tags,
        };

        fullRecipe.CookingSteps = ConvertCookingStepDocumentToCookingStep(recipe.CookingSteps);
        fullRecipe.Utensils = ConvertUtensilPartDocumentToUtensilPart(recipe.Utensils);
        fullRecipe.ShoppingItems = ConvertShoppingItemDocumentToShoppingItem(recipe.ShoppingItems);
        fullRecipe.Tips = ConvertTipDocumentToTip(recipe.Tips);
        return fullRecipe;
    }

    private static List<Tip> ConvertTipDocumentToTip(List<TipDocument> tips)
    {
        var convertedTips = new List<Tip>();
        if (tips.Count != 0)
        {
            convertedTips.AddRange(tips.Select(tip => new Tip { Id = tip.Id, Description = tip.Description }));
        }
        return convertedTips;
    }

    private static List<ShoppingItem> ConvertShoppingItemDocumentToShoppingItem(List<ShoppingItemDocument> shoppingList)
    {
        var convertedShoppngList = new List<ShoppingItem>();
        if (shoppingList is not null || shoppingList.Count != 0)
        {
            convertedShoppngList.AddRange(shoppingList.Select(item => new ShoppingItem
            {
                Quantity = item.Quantity,
                Measure = item.Measure,
                AdditionalInformation = item.AdditionalInformation,
                Ingredient = new Ingredient { Id = item.Ingredient.Id, Name = item.Ingredient.Name }
            }));
        }
        return convertedShoppngList;
    }

    private static List<UtensilPart> ConvertUtensilPartDocumentToUtensilPart(List<UtensilPartDocument>? utensils)
    {
        var convertedUtensils = new List<UtensilPart>();
        if (utensils is not null || utensils.Count != 0)
        {
            foreach (var item in utensils)
            {
                convertedUtensils.Add(new UtensilPart
                {
                    RequiredAmount = item.RequiredAmount,
                    Utensil = new Utensil { Id = item.Utensil.Id, Name = item.Utensil.Name }
                });
            }
        }
        return convertedUtensils;
    }

    private static List<CookingStep> ConvertCookingStepDocumentToCookingStep(List<CookingStepDocument> steps)
    {
        var convertedSteps = new List<CookingStep>();
        if (steps is not null || steps.Count != 0)
        {
            foreach (var step in steps)
            {
                var cookingStep = new CookingStep
                {
                    OrderNumber = step.OrderNumber,
                    StepDescription = step.StepDescription
                };
                if (step.StepIngredients is not null || step.StepIngredients.Count > 0)
                {
                    cookingStep.StepIngredients = ConvertStepIngredientDocumentToStepIngredient(step);
                }
                convertedSteps.Add(cookingStep);
            }
        }
        return convertedSteps;
    }

    private static List<StepIngredient> ConvertStepIngredientDocumentToStepIngredient(CookingStepDocument step)
    {
        var ingredients = new List<StepIngredient>();
        if (step is not null && step.StepIngredients.Count != 0)
        {
            foreach (var ing in step.StepIngredients)
            {
                ingredients.Add(new StepIngredient()
                {
                    Quantity = ing.Quantity,
                    Measure = ing.Measure,
                    Ingredient = ing.Ingredient
                });
            }
        }
        return ingredients;
    }
}
