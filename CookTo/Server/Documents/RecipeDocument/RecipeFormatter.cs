using CookTo.Server.Documents.RecipeDocument;
using CookTo.Server.Helpers;
using System.Text;

namespace CookTo.Server.Documents.RecipeDocument;

public static class RecipeFormatter
{
    public static Recipe Format(Recipe recipe)
    {
        recipe.Title = ParseText.TitleCapitalize(recipe.Title);

        var descriptionSentences = recipe.Description.Trim().Split('.');
        StringBuilder sb = new StringBuilder();
        foreach(var sentence in descriptionSentences)
        {
            if(string.IsNullOrWhiteSpace(sentence))
            {
                continue;
            }
            sb.Append(ParseText.FormatText(sentence));
            sb.Append(".");
        }
        recipe.Description = sb.ToString().TrimEnd();
        recipe.Creator = string.IsNullOrEmpty(recipe.Creator) ? string.Empty : ParseText.TitleCapitalize(recipe.Creator);
        foreach(var part in recipe.RecipeParts)
        {
            part.PartTitle = ParseText.TitleCapitalize(part.PartTitle);
            foreach(var item in part.Items)
            {
                if(!string.IsNullOrWhiteSpace(item.AdditionalInformation))
                {
                    item.AdditionalInformation = item.AdditionalInformation.ToLower().TrimStart().TrimEnd();
                }
            }
        }


        foreach(var step in recipe.CookingSteps)
        {
            step.StepDescription = ParseText.FormatText(step.StepDescription);
        }

        return recipe;
    }
}
