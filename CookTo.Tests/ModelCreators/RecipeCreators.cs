using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;
using CookTo.Shared.Modules.ManageUtensils;
using System;
using System.Collections.Generic;

namespace CookTo.Tests.ModelCreators;

public class RecipeCreators
{
    public static Recipe ValidModel() => TemplateRecipe();

    private static Recipe TemplateRecipe()
    {
        var model = new Recipe()
        {
            Id = Guid.NewGuid().ToString(),
            Title = "A recipe",
            Category = new Category { Id = Guid.NewGuid().ToString(), Text = "Catergory text" },
            Cuisine = new Cuisine { Id = Guid.NewGuid().ToString(), Text = "Cuisine text" },
            Description = "Description Text that is valid ",
            Image = "someImage.jpg",
            PrepTime = 10,
            CookTime = 10,
            Creator = "Bobs your uncle",
            AddedBy = "super sally",
            Serves = "2",
            Dietaries = new List<Dietary> { Dietary.Vegan },
            Utensils =
                new List<UtensilPart>() {
                new UtensilPart()
                {
                    RequiredAmount = 1,
                    Utensil = new Utensil { Id = Guid.NewGuid().ToString(), Text = "utensil a" }
                }, new UtensilPart()
                   {
                       RequiredAmount = 2,
                       Utensil = new Utensil { Id = Guid.NewGuid().ToString(), Text = "utensil b" }
                   } },
            CookingSteps =
                new List<CookingStep>()
            {
                new CookingStep
                {
                    OrderNumber = 1,
                    StepDescription = "Some description of what happens 1",
                    StepIngredients = new List<StepIngredient>()
                },
                new CookingStep
                {
                    OrderNumber = 2,
                    StepDescription = "Some description of what happens 2",
                    StepIngredients =
                        new List<StepIngredient>
                    {
                        new StepIngredient { Quantity = "1", Measure = "g", Ingredient = "sugar" },
                        new StepIngredient { Quantity = "a", Measure = string.Empty, Ingredient = "egg" } }
                },
                new CookingStep
                {
                    OrderNumber = 3,
                    StepDescription = "Some description of what happens 3",
                    StepIngredients =
                        new List<StepIngredient>
                    {
                        new StepIngredient { Quantity = "3", Measure = "g", Ingredient = "butter" } }
                } },
            ShoppingList =
                new List<ShoppingItem>()
           {
               new ShoppingItem
               {
                   Quantity = "10",
                   Measure = "g",
                   AdditionalInformation = "cubed",
                   Ingredient = new Ingredient { Id = Guid.NewGuid().ToString(), Text = "butter" }
               },
               new ShoppingItem
               {
                   Quantity = string.Empty,
                   Measure = "a",
                   AdditionalInformation = string.Empty,
                   Ingredient = new Ingredient { Id = Guid.NewGuid().ToString(), Text = "egg" }
               },
               new ShoppingItem
               {
                   Quantity = "5",
                   Measure = "g",
                   AdditionalInformation = string.Empty,
                   Ingredient = new Ingredient { Id = Guid.NewGuid().ToString(), Text = "sugar" }
               } },
            Tips = new List<Tip> { new Tip { Description = "some tip" } },
            Tags = "butter,egg,sugar"
        };
        return model;
    }
}
