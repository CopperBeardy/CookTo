namespace CookTo.Server.Modules.Recipes.Helpers;

public static class FractionConvertor
{
    public static double ParseFraction(string quantity)
    {
        var parseQuantity = 0.0;
        var values = quantity.Split(new char[] { ',', ' ' });
        if(values.Length == 2)
        {
            quantity = (int.Parse(values[0]) / int.Parse(values[1])).ToString();
        } else
        {
            quantity = (int.Parse(values[0]) + (int.Parse(values[1]) / int.Parse(values[2]))).ToString();
        }
        ;

        return parseQuantity;
    }
}
