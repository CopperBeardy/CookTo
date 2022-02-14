﻿using CookTo.Shared.Enums;

namespace CookTo.Shared.Features.ManageRecipes;

public class RecipeDto
{
    public string? Id { get; set; }

    public string Title { get; set; }

    public string Cuisine { get; set; }

    public Category Category { get; set; }

    public string Description { get; set; }

    public string? Image { get; set; }

    public int PreparationTime { get; set; }

    public int CookingTime { get; set; }

    public int Serves { get; set; }

    public string AuthorId { get; set; }

    public List<Dietary> Dietaries { get; set; }

    public List<RecipePart> RecipeParts { get; set; } = new List<RecipePart>();

    public List<UtensilPart> Utensils { get; set; } = new List<UtensilPart>();

    public List<CookingStep> CookingSteps { get; set; } = new List<CookingStep>();

    public List<string>? Tips { get; set; }


    public ImageAction ImageAction { get; set; }
}
