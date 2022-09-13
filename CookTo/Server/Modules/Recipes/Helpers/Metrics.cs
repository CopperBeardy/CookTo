using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageRecipes;
using MeasurementConverters.Mass;
using MeasurementConverters.Volume;

namespace CookTo.Server.Modules.Recipes.Helpers;

public static class Metrics
{
    //public static List<CookingStep> Convert(List<CookingStep> steps)
    //{
    //    foreach (var step in steps)
    //    {
    //        foreach (var ing in step.StepIngredients)
    //        {
    //            if (ing.Measure == || ing.Measure == "oz")
    //            {
    //                var result = ConvertToMetric(ing.Quantity, ing.Measure);
    //                ing.Quantity = result.quantity;
    //                ing.Measure = result.measure;
    //            }
    //        }
    //    }

    //    return steps;
    //}

    //private static (string quantity, string measure) ConvertToMetric(string quantity, string measure)
    //{
    //    var convertedQuantity = string.Empty;
    //    var convertedMeasure = string.Empty;

    //    if (quantity.Contains('/'))
    //    {
    //        quantity = FractionConvertor.ParseFraction(quantity).ToString();
    //    }

    //    switch (measure)
    //    {
    //        case "floz":
    //            convertedQuantity = VolumeConverter.Convert(double.Parse(quantity), VolumeUnit.floz, VolumeUnit.mL)
    //                .ToString();
    //            convertedMeasure = "ml";
    //            break;
    //        case "oz":
    //            convertedQuantity = MassConverter.Convert(double.Parse(quantity), MassUnit.oz, MassUnit.g).ToString();
    //            convertedMeasure = "g";
    //            break;
    //        case "lb":
    //            convertedQuantity = MassConverter.Convert(double.Parse(quantity), MassUnit.lb, MassUnit.g).ToString();
    //            convertedMeasure = "g";
    //            break;
    //    }

    //    return (convertedQuantity, convertedMeasure);
    //}
}
