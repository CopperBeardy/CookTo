using CookTo.Server.Modules.Recipes.Core;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Shared.Modules.ManageUtensils;
using System.Linq;

namespace CookTo.Server.Modules.Recipes.Helpers;

public static class RecipeDocumentToRecipeConverter
{
    public static Recipe Convert(RecipeDocument recipe)
    {
        var fullRecipe = new Recipe()
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Cuisine = new Cuisine { Id = recipe.Cuisine.Id, Text = recipe.Cuisine.Text },
            Category = new Category { Id = recipe.Category.Id, Text = recipe.Category.Text },
            Description = recipe.Description,
            Image = recipe.Image,
            PrepTime = recipe.PrepTime,
            CookTime = recipe.CookTime,
            Serves = recipe.Serves,
            Creator = recipe.Creator,
            AddedBy = recipe.AddedBy,
            Dietaries = recipe.Dietaries,
            Tips = recipe.Tips,
            Tags = recipe.Tags,
        };

        fullRecipe.CookingSteps = ConvertCookingStepDocumentToCookingStep(recipe.CookingSteps);
        fullRecipe.Utensils = ConvertUtensilPartDocumentToUtensilPart(recipe.Utensils);
        fullRecipe.ShoppingItems = ConvertShoppingItemDocumentToShoppingItem(recipe.ShoppingItems);
        return fullRecipe;
    }

    private static List<ShoppingItem> ConvertShoppingItemDocumentToShoppingItem(List<ShoppingItemDocument> shoppingList)
    {
        var convertedShoppngList = new List<ShoppingItem>();
        convertedShoppngList.AddRange(shoppingList.Select(item => new ShoppingItem
            {
                Quantity = item.Quantity,
                Measure = item.Measure,
                AdditionalInformation = item.AdditionalInformation,
                Ingredient = new Ingredient { Id = item.Ingredient.Id, Text = item.Ingredient.Text }
            }));
        return convertedShoppngList;
    }

    private static List<UtensilPart> ConvertUtensilPartDocumentToUtensilPart(List<UtensilPartDocument>? utensils)
    {
        var convertedUtensils = new List<UtensilPart>();
        foreach(var item in utensils)
        {
            convertedUtensils.Add(new UtensilPart
                {
                    RequiredAmount = item.RequiredAmount,
                    Utensil = new Utensil { Id = item.Utensil.Id, Text = item.Utensil.Text }
                });
        }
        return convertedUtensils;
    }

    private static List<CookingStep> ConvertCookingStepDocumentToCookingStep(List<CookingStepDocument> steps)
    {
        var convertedSteps = new List<CookingStep>();
        foreach(var step in steps)
        {
            var cookingStep = new CookingStep { OrderNumber = step.OrderNumber, StepDescription = step.StepDescription };
            if(step.StepIngredients is not null || step.StepIngredients.Count > 0)
            {
                cookingStep.StepIngredients = ConvertStepIngredientDocumentToStepIngredient(step);
            }
            convertedSteps.Add(cookingStep);
        }
        return convertedSteps;
    }

    private static List<StepIngredient> ConvertStepIngredientDocumentToStepIngredient(CookingStepDocument step)
    {
        var ingredients = new List<StepIngredient>();
        foreach(var ing in step.StepIngredients)
        {
            ingredients.Add(new StepIngredient()
                {
                    Quantity = ing.Quantity,
                    Measure = ing.Measure,
                    Ingredient = ing.Ingredient
                });
        }
        return ingredients;
    }
}
