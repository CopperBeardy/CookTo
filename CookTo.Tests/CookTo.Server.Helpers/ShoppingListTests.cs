using CookTo.Server.Documents;
using CookTo.Server.Helpers;
using CookTo.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CookTo.Tests.CookTo.Server.Helpers;

public class ShoppingListTests
{
    [Fact]
    public void ConvertToMilliliters_MeasureUnit_tsp_liquid_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new PartIngredientDocument()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.tsp_liquid,
            Amount = 1,
            Ingredient = new IngredientDocument() { Id = "aaa", Name = "test1" }
        };

        var response = ShoppingList.ConvertToMilliliters(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<PartIngredientDocument>(response);

        Assert.Equal(5, result.Amount);
        Assert.Equal(MeasureUnit.ml, result.Unit);
    }

    [Fact]
    public void ConvertToMilliliters_MeasureUnit_tbsp_liquid_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new PartIngredientDocument()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.tbsp_liquid,
            Amount = 1,
            Ingredient = new IngredientDocument() { Id = "aaa", Name = "test1" }
        };

        var response = ShoppingList.ConvertToMilliliters(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<PartIngredientDocument>(response);

        Assert.Equal(15, result.Amount);
        Assert.Equal(MeasureUnit.ml, result.Unit);
    }

    [Fact]
    public void ConvertToGrams_MeasureUnit_tsp_dry_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new PartIngredientDocument()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.tsp_dry,
            Amount = 1,
            Ingredient = new IngredientDocument() { Id = "aaa", Name = "test1" }
        };

        var response = ShoppingList.ConvertToGrams(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<PartIngredientDocument>(response);

        Assert.Equal(6, result.Amount);
        Assert.Equal(MeasureUnit.g, result.Unit);
    }

    [Fact]
    public void ConvertToGrams_MeasureUnit_tbsp_dry_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new PartIngredientDocument()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.tbsp_dry,
            Amount = 1,
            Ingredient = new IngredientDocument() { Id = "aaa", Name = "test1" }
        };

        var response = ShoppingList.ConvertToGrams(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<PartIngredientDocument>(response);

        Assert.Equal(15, result.Amount);
        Assert.Equal(MeasureUnit.g, result.Unit);
    }

    [Fact]
    public void ConvertToGrams_MeasureUnit_pinch_Valid_SectionPartIngredient_Success()
    {
        var partIngredient = new PartIngredientDocument()
        {
            AdditionalInformation = string.Empty,
            Unit = MeasureUnit.pinch,
            Amount = 1,
            Ingredient = new IngredientDocument() { Id = "aaa", Name = "test1" }
        };

        var response = ShoppingList.ConvertToGrams(partIngredient);

        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<PartIngredientDocument>(response);

        Assert.Equal(2, result.Amount);
        Assert.Equal(MeasureUnit.g, result.Unit);
    }

    [Fact]
    public void GroupByIngredientName_Valid_Success()
    {
        var items = new List<PartIngredientDocument>()
        {
            new PartIngredientDocument()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.g,
                Amount = 1,
                Ingredient = new IngredientDocument() { Id = "aaa", Name = "test1" }
            },
            new PartIngredientDocument()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.g,
                Amount = 1,
                Ingredient = new IngredientDocument() { Id = "aaa", Name = "test1" }
            },
            new PartIngredientDocument()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.ml,
                Amount = 1,
                Ingredient = new IngredientDocument() { Id = "aaa", Name = "test2" }
            }
        };

        var response = ShoppingList.GroupByIngredientName(items);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<PartIngredientDocument>>(response);
        Assert.Equal(2, result.Count);
        Assert.Equal("test1", result[0].Ingredient.Name);
        Assert.Equal(2, result[0].Amount);
    }

    [Fact]
    public void CreateShoppingListValues_Has_Measure_Unit_Valid_Success()
    {
        var items = new List<PartIngredientDocument>()
        {
            new PartIngredientDocument()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.g,
                Amount = 100,
                Ingredient = new IngredientDocument() { Id = "aaa", Name = "sugar" }
            }
        };

        var response = ShoppingList.CreateShoppingListValues(items);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<string>>(response);
        Assert.Equal(1, result.Count);
        Assert.Equal("100g sugar", result[0]);
    }

    [Fact]
    public void CreateShoppingListValues_Has_No_Measure_unit_And_Single_Amount_Valid_Success()
    {
        var items = new List<PartIngredientDocument>()
        {
            new PartIngredientDocument()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.None,
                Amount = 1,
                Ingredient = new IngredientDocument() { Id = "aaa", Name = "egg" }
            }
        };

        var response = ShoppingList.CreateShoppingListValues(items);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<string>>(response);
        Assert.Equal(1, result.Count);
        Assert.Equal("A egg", result[0]);
    }

    [Fact]
    public void CreateShoppingListValues_Has_No_Measure_unit_And_Greater_Than_One_Amount_Valid_Success()
    {
        var items = new List<PartIngredientDocument>()
        {
            new PartIngredientDocument()
            {
                AdditionalInformation = string.Empty,
                Unit = MeasureUnit.None,
                Amount = 2,
                Ingredient = new IngredientDocument() { Id = "aaa", Name = "egg" }
            }
        };

        var response = ShoppingList.CreateShoppingListValues(items);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<string>>(response);
        Assert.Equal(1, result.Count);
        Assert.Equal("2 egg's", result[0]);
    }

    [Fact]
    public void Generate_Valid_Recipe_Model_Values_Returns_List_string_Success()
    {
        var recipe = new RecipeDocument()
        {
            RecipeParts =
                new List<RecipePartDocument>()
                {
                    new RecipePartDocument()
                    {
                        Items =
                            new List<PartIngredientDocument>()
                                {
                                    new PartIngredientDocument()
                                    {
                                        Amount = 100,
                                        Ingredient = new IngredientDocument() { Name = "Sugar" },
                                        Unit = MeasureUnit.g
                                    },
                                    new PartIngredientDocument()
                                    {
                                        Amount = 1,
                                        Ingredient = new IngredientDocument() { Name = "Salt" },
                                        Unit = MeasureUnit.pinch
                                    }
                                }
                    },
                    new RecipePartDocument()
                    {
                        Items =
                            new List<PartIngredientDocument>()
                                {
                                    new PartIngredientDocument()
                                    {
                                        Amount = 2,
                                        Ingredient = new IngredientDocument() { Name = "Sugar" },
                                        Unit = MeasureUnit.tsp_dry
                                    }
                                }
                    }
                }
        };

        var response = ShoppingList.Generate(recipe);
        Assert.NotNull(response);
        var result = Assert.IsAssignableFrom<List<string>>(response);
        Assert.Equal(2, result.Count);
        Assert.Contains("112g Sugar", result);
    }
}
