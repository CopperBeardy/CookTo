using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageRecipes;
using System.Collections.Generic;
using Xunit;

namespace CookTo.Tests.CookTo.Server.Helpers;

public class ShoppingListTests
{
    [Fact]
    public void ConvertToMilliliters_MeasureUnit_tsp_liquid_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new StepIngredient()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.tsp_liquid,
            Amount = 1,
            Ingredient = new Ingredient() { Id = "aaa", Text = "test1" }
        };

        var response = ShoppingList.ConvertToMilliliters(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<StepIngredient>(response);

        Assert.Equal(5, result.Amount);
        Assert.Equal(MeasureUnit.ml, result.Unit);
    }

    [Fact]
    public void ConvertToMilliliters_MeasureUnit_tbsp_liquid_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new StepIngredient()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.tbsp_liquid,
            Amount = 1,
            Ingredient = new Ingredient() { Id = "aaa", Text = "test1" }
        };

        var response = ShoppingList.ConvertToMilliliters(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<StepIngredient>(response);

        Assert.Equal(15, result.Amount);
        Assert.Equal(MeasureUnit.ml, result.Unit);
    }

    [Fact]
    public void ConvertToGrams_MeasureUnit_tsp_dry_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new StepIngredient()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.tsp_dry,
            Amount = 1,
            Ingredient = new Ingredient() {  Id = "aaa", Text = "test1" }
        };

        var response = ShoppingList.ConvertToGrams(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<StepIngredient>(response);
       
        Assert.Equal(6, result.Amount);
        Assert.Equal(MeasureUnit.g, result.Unit);
    }

    [Fact]
    public void ConvertToGrams_MeasureUnit_tbsp_dry_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new StepIngredient()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.tbsp_dry,
            Amount = 1,
            Ingredient = new Ingredient() { Id = "aaa", Text = "test1" }
        };

        var response = ShoppingList.ConvertToGrams(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<StepIngredient>(response);

        Assert.Equal(15, result.Amount);
        Assert.Equal(MeasureUnit.g, result.Unit);
    }

    [Fact]
    public void ConvertToGrams_MeasureUnit_pinch_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new StepIngredient()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.pinch,
            Amount = 1,
            Ingredient = new Ingredient() { Id = "aaa", Text = "test1" }
        };

        var response = ShoppingList.ConvertToGrams(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<StepIngredient>(response);

        Assert.Equal(2, result.Amount);
        Assert.Equal(MeasureUnit.g, result.Unit);
    }

    [Fact]
    public void GroupByIngredientName_Valid_Success()
    {
        var items = new List<StepIngredient>()
        {
            new StepIngredient()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.g,
                Amount = 1,
                Ingredient = new Ingredient() { Id = "aaa", Text = "test1" }
            },
            new StepIngredient()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.g,
                Amount = 1,
                Ingredient = new Ingredient() { Id = "aaa", Text = "test1" }
            },
            new StepIngredient()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.ml,
                Amount = 1,
                Ingredient = new Ingredient() { Id = "aaa", Text = "test2" }
            }
        };

        var response = ShoppingList.GroupByIngredientName(items);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<StepIngredient>>(response);

        Assert.Equal(2, result.Count);
        Assert.Equal("test1", result[0].Ingredient.Text);
        Assert.Equal(2, result[0].Amount);
    }

    [Fact]
    public void CreateShoppingListValues_Has_Measure_Unit_Valid_Success()
    {
        var items = new List<StepIngredient>()
        {
            new StepIngredient()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.g,
                Amount = 100,
                Ingredient = new Ingredient() { Id = "aaa", Text = "sugar" }
            }
        };

        var response = ShoppingList.CreateShoppingListValues(items);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<string>>(response);
        Assert.Single(result);
        Assert.Equal("100g sugar", result[0]);
    }

    [Fact]
    public void CreateShoppingListValues_Has_No_Measure_unit_And_Single_Amount_Valid_Success()
    {
        var items = new List<StepIngredient>()
        {
            new StepIngredient()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.None,
                Amount = 1,
                Ingredient = new Ingredient() { Id = "aaa", Text = "egg" }
            }
        };

        var response = ShoppingList.CreateShoppingListValues(items);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<string>>(response);
        Assert.Single(result);
        Assert.Equal("A egg", result[0]);
    }

    [Fact]
    public void CreateShoppingListValues_Has_No_Measure_unit_And_Greater_Than_One_Amount_Valid_Success()
    {
        var items = new List<StepIngredient>()
        {
            new StepIngredient()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.None,
                Amount = 2,
                Ingredient = new Ingredient() { Id = "aaa", Text = "egg" }
            }
        };

        var response = ShoppingList.CreateShoppingListValues(items);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<string>>(response);
        Assert.Single(result);
        Assert.Equal("2 egg's", result[0]);
    }

    [Fact]
    public void Generate_Valid_Recipe_Model_Values_Returns_List_string_Success()
    {
        var recipe = new FullRecipe()
        {
            CookingSteps = new List<CookingStep>()
            {

            new CookingStep()
            {
                        OrderNumber =1,
                        StepDescription="do stuff",
                       StepIngredients =  new List<StepIngredient>()
                       {
                                    new StepIngredient()
                                    {
                                        Amount = 100,
                                        Ingredient = new Ingredient() { Text = "Sugar" },
                                        Unit = MeasureUnit.g
                                    },
                                    new StepIngredient()
                                    {
                                        Amount = 1,
                                        Ingredient = new Ingredient() { Text = "Salt" },
                                        Unit = MeasureUnit.pinch
                                    }
                                }
                    },
                    new CookingStep()
                    {
                        OrderNumber =2,
                        StepDescription="do some other stuff",
                        StepIngredients =
                            new List<StepIngredient>()
                                {
                                    new StepIngredient()
                                    {
                                        Amount = 2,
                                        Ingredient = new Ingredient() { Text = "Sugar" },
                                        Unit = MeasureUnit.tsp_dry
                                    }
                                }

                }
        }
        };

        var response = ShoppingList.Generate(recipe.CookingSteps);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<string>>(response);
        Assert.Equal(2, result.Count);
        Assert.Contains("112g Sugar", result);
    }
}
