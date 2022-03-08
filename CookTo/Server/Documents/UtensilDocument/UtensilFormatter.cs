using CookTo.Server.Helpers;
using System.Text;
using System.Text.RegularExpressions;

namespace CookTo.Server.Documents.UtensilDocument;

public static class UtensilFormatter
{
    public static Utensil Format(Utensil utensil)
    {
        //change to lower
        var utensilName = utensil.UtensilName.ToLower().TrimStart().TrimEnd();
        var firstChar = utensilName[0].ToString();

        //check to see if name starts with a number
        var isNumber = Regex.IsMatch(firstChar, @"^\d+");
        if(isNumber)
        {
            //if number look for whitespace 
            var indexOfFirstWhiteSpace = utensilName.IndexOf(" ");

            var  size = utensilName.Substring(0, indexOfFirstWhiteSpace - 1);
            var  name = utensilName.Substring(indexOfFirstWhiteSpace + 1);
            // capitilize first letter
            name = ParseText.CapitalizeFirstLetter(name);

            // recombine parts
            StringBuilder sb = new StringBuilder();
            utensil.UtensilName = sb.Append(size).Append(" ").Append(name).ToString();
        } else
        {
            // capitilize first letter
            utensil.UtensilName = ParseText.CapitalizeFirstLetter(utensilName);
        }

        return utensil;
    }
}
