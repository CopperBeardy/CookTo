using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Server.Modules.Utensils.Core;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Shared.Modules.ManageUtensils;
using System.Linq;

namespace CookTo.Server.Modules.Recipes.Helpers;

public static class RecipeToRecipeDocumentConverter
{
    public static RecipeDocument Convert(Recipe recipe)
    {
        var recipeDoc = new RecipeDocument()
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Cuisine = new CuisineDocument { Id = recipe.Cuisine.Id, Text = recipe.Cuisine.Text },
            Category = new CategoryDocument { Id = recipe.Category.Id, Text = recipe.Category.Text },
            Description = recipe.Description,
            Image = recipe.Image,
            PrepTime = recipe.PrepTime,
            CookTime = recipe.CookTime,
            Serves = recipe.Serves,
            Creator = recipe.Creator,
            AddedBy = recipe.AddedBy,
            Dietaries = recipe.Dietaries,
            Tips = recipe.Tips,
            Tags = TagHelper.GenerateTags(recipe.Category, recipe.Cuisine, recipe.ShoppingList),
        };

        recipeDoc.CookingSteps = ConvertCookingStepToCookingStepDocument(recipe.CookingSteps);
        recipeDoc.Utensils = ConvertUtensilPartToUtensilPartDocument(recipe.Utensils);
        recipeDoc.ShoppingList = ConvertShoppingItemToShoppingItemDocument(recipe.ShoppingList);
        return recipeDoc;
    }

    static List<ShoppingItemDocument> ConvertShoppingItemToShoppingItemDocument(List<ShoppingItem> shoppingList)
    {
        var convertedShoppngList = new List<ShoppingItemDocument>();
        convertedShoppngList.AddRange(shoppingList.Select(item => new ShoppingItemDocument
            {
                Quantity = item.Quantity,
                Measure = item.Measure,
                AdditionalInformation = item.AdditionalInformation,
                Ingredient = new IngredientDocument { Id = item.Ingredient.Id, Text = item.Ingredient.Text }
            }));
        return convertedShoppngList;
    }

    private static List<UtensilPartDocument> ConvertUtensilPartToUtensilPartDocument(List<UtensilPart> utensils)
    {
        var convertedUtensils = new List<UtensilPartDocument>();
        foreach(var item in utensils)
        {
            convertedUtensils.Add(new UtensilPartDocument
                {
                    RequiredAmount = item.RequiredAmount,
                    Utensil = new UtensilDocument { Id = item.Utensil.Id, Text = item.Utensil.Text }
                });
        }
        return convertedUtensils;
    }

    private static List<CookingStepDocument> ConvertCookingStepToCookingStepDocument(List<CookingStep> steps)
    {
        var convertedSteps = new List<CookingStepDocument>();
        foreach(var step in steps)
        {
            var cookingStep = new CookingStepDocument
            {
                OrderNumber = step.OrderNumber,
                StepDescription = step.StepDescription
            };
            if(step.StepIngredients is not null || step.StepIngredients.Count > 0)
            {
                cookingStep.StepIngredients = ConvertStepIngredientToStepIngredientDocument(step);
            }
            convertedSteps.Add(cookingStep);
        }
        return convertedSteps;
    }

    private static List<StepIngredientDocument> ConvertStepIngredientToStepIngredientDocument(CookingStep step)
    {
        var ingredients = new List<StepIngredientDocument>();
        foreach(var ing in step.StepIngredients)
        {
            ingredients.Add(new StepIngredientDocument()
                {
                    Quantity = ing.Quantity,
                    Measure = ing.Measure,
                    Ingredient = ing.Ingredient
                });
        }
        return ingredients;
    }
}
