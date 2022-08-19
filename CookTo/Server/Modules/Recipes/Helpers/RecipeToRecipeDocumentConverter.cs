using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Recipes.Helpers;

public static class RecipeToRecipeDocumentConverter
{
    public static RecipeDocument Convert(Recipe recipe)
    {
        var recipeDoc = new RecipeDocument()
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Cuisine = new CuisineDocument { Id = recipe.Cuisine.Id, Name = recipe.Cuisine.Name },
            Category = new CategoryDocument { Id = recipe.Category.Id, Name = recipe.Category.Name },
            Description = recipe.Description,
            Image = recipe.Image,
            PrepTime = recipe.PrepTime,
            CookTime = recipe.CookTime,
            Serves = recipe.Serves,
            Creator = recipe.Creator,
            AddedBy = recipe.AddedBy,
            Dietaries = recipe.Dietaries,

            Tags = TagHelper.GenerateTags(recipe.Category, recipe.Cuisine, recipe.ShoppingItems),
        };

        recipeDoc.CookingSteps = ConvertCookingStepToCookingStepDocument(recipe.CookingSteps);
        recipeDoc.Utensils = ConvertUtensilPartToUtensilPartDocument(recipe.Utensils);
        recipeDoc.ShoppingItems = ConvertShoppingItemToShoppingItemDocument(recipe.ShoppingItems);

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
            Ingredient = new IngredientDocument { Id = item.Ingredient.Id, Name = item.Ingredient.Name }
        }));
        return convertedShoppngList;
    }

    private static List<UtensilPartDocument> ConvertUtensilPartToUtensilPartDocument(List<UtensilPart> utensils)
    {
        var convertedUtensils = new List<UtensilPartDocument>();
        foreach (var item in utensils)
        {
            convertedUtensils.Add(new UtensilPartDocument
            {
                RequiredAmount = item.RequiredAmount,
                Utensil = new UtensilDocument { Id = item.Utensil.Id, Name = item.Utensil.Name }
            });
        }
        return convertedUtensils;
    }

    private static List<CookingStepDocument> ConvertCookingStepToCookingStepDocument(List<CookingStep> steps)
    {
        var convertedSteps = new List<CookingStepDocument>();
        foreach (var step in steps)
        {
            var cookingStep = new CookingStepDocument
            {
                OrderNumber = step.OrderNumber,
                StepDescription = step.StepDescription
            };
            if (step.StepIngredients is not null || step.StepIngredients.Count > 0)
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
        foreach (var ing in step.StepIngredients)
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
