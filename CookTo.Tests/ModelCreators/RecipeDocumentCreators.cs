using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Server.Modules.Utensils.Core;
using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageRecipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Tests.ModelCreators;

public static class RecipeDocumentCreators
{
    public static RecipeDocument ValidModel() => TemplateRecipeDocument();

    public static RecipeDocument NulledValuedModel()
    {
        var model = TemplateRecipeDocument();
        model.Category = null;
        model.Cuisine = null;
        return model;
    }

    private static RecipeDocument TemplateRecipeDocument()
    {
        var model = new RecipeDocument()
        {
            Id = Guid.NewGuid().ToString(),
            Title = "A recipe",
            Category = new CategoryDocument { Id = Guid.NewGuid().ToString(), Text = "Catergory text" },
            Cuisine = new CuisineDocument { Id = Guid.NewGuid().ToString(), Text = "Cuisine text" },
            Description = "Description Text that is valid ",
            Image = "someImage.jpg",
            PrepTime = 10,
            CookTime = 10,
            Creator = "Bobs your uncle",
            AddedBy = "super sally",
            Serves = "2",
            Dietaries = new List<Dietary> { Dietary.Vegan },
            Utensils =
                new List<UtensilPartDocument>() {
                new UtensilPartDocument()
                {
                    RequiredAmount = 1,
                    Utensil = new UtensilDocument { Id = Guid.NewGuid().ToString(), Text = "utensil a" }
                }, new UtensilPartDocument()
                   {
                       RequiredAmount = 2,
                       Utensil = new UtensilDocument { Id = Guid.NewGuid().ToString(), Text = "utensil b" }
                   } },
            CookingSteps =
                new List<CookingStepDocument>()
            {
                new CookingStepDocument
                {
                    OrderNumber = 1,
                    StepDescription = "Some description of what happens 1",
                    StepIngredients = new List<StepIngredientDocument>()
                },
                new CookingStepDocument
                {
                    OrderNumber = 2,
                    StepDescription = "Some description of what happens 2",
                    StepIngredients =
                        new List<StepIngredientDocument>
                    {
                        new StepIngredientDocument { Quantity = "1", Measure = "g", Ingredient = "sugar" },
                        new StepIngredientDocument { Quantity = "a", Measure = string.Empty, Ingredient = "egg" } }
                },
                new CookingStepDocument
                {
                    OrderNumber = 3,
                    StepDescription = "Some description of what happens 3",
                    StepIngredients =
                        new List<StepIngredientDocument>
                    {
                        new StepIngredientDocument { Quantity = "3", Measure = "g", Ingredient = "butter" } }
                } },
            ShoppingList =
                new List<ShoppingItemDocument>()
           {
               new ShoppingItemDocument
               {
                   Id = 1,
                   Quantity = "10",
                   Measure = "g",
                   AdditionalInformation = "cubed",
                   Ingredient = new IngredientDocument { Id = Guid.NewGuid().ToString(), Text = "butter" }
               },
               new ShoppingItemDocument
               {
                   Id = 1,
                   Quantity = string.Empty,
                   Measure = "a",
                   AdditionalInformation = string.Empty,
                   Ingredient = new IngredientDocument { Id = Guid.NewGuid().ToString(), Text = "egg" }
               },
               new ShoppingItemDocument
               {
                   Id = 1,
                   Quantity = "5",
                   Measure = "g",
                   AdditionalInformation = string.Empty,
                   Ingredient = new IngredientDocument { Id = Guid.NewGuid().ToString(), Text = "sugar" }
               } },
            Tips = new List<Tip> { new Tip { Description = "some tip" } },
            Tags = "butter,egg,sugar"
        };
        return model;
    }
}
