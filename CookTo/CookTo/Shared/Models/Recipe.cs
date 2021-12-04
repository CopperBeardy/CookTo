using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class Recipe
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string PrepartionTime { get; set; }
        public string CookingTime { get; set; }
        public string Serves { get; set; }
        public string AuthorId { get; set; }
        public List<RecipePart> RecipeParts { get; set; }
        public List<CookingStep> CookingSteps { get; set; }
        public List<Tip>? Tips { get; set; }
        public string CreationDate { get; set; }
    }



