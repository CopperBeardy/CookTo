using System.Globalization;
using System.Text.RegularExpressions;

namespace CookTo.Server.Helpers;

public static class ParseText
{
    public static string RemoveSpecialCharacters(this string input) => Regex.Replace(
        input,
        @"[^\w\. \,\-\/ 0 - 9]|([ \t]\/*[ \t])",
        " ")
        .Trim();

    public static string FormatText(string input) => RemoveSpecialCharacters(input)
        .RemoveMultipleFullStops()
        .RemoveSpacesBetweenWordAndFullStop()
        .InsertSpaceAfterFullStop()
        .CapitalizeFirstLetter()
        .RemoveMultipleFullStops();


    public static string RemoveMultipleSpaces(this string input)
    { return Regex.Replace(input, @"[ ]{2,}", @" ", RegexOptions.None); }

    public static string RemoveMultipleFullStops(this string input) => Regex.Replace(input, @"[.]{2,}", ".");

    public static string RemoveSpacesBetweenWordAndFullStop(this string input) => Regex.Replace(
        input,
        @"\s+(?=[.,?!])",
        string.Empty);

    public static string InsertSpaceAfterFullStop(this string input) => Regex.Replace(input, @"[.]\b(?=\w)[0-9]", ". ");

    public static string CapitalizeFirstLetter(this string input)
    {
        var capitalized = input.Substring(0, 1).ToUpper();
        var modified = input.Remove(0, 1);
        modified = modified.Insert(0, capitalized);
        return modified;
    }

    public static string TitleCapitalize(this string input) => CultureInfo.CurrentCulture.TextInfo
        .ToTitleCase(input.ToLower());
}
