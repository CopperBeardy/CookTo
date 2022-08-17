using Bogus;
using CookTo.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Tests.Fakes;

public static class SharedGenerators
{
    public static string[] Measures = { "g", "l", "tsp", "pinch" };

    public static List<string> GenerateShoppingList()
    {
        var items = new List<string> { "3 Eggs", "100g white bread flour", "pinch fine salt", "200ml milk", "caster sugar", "2tsp cinnamon" };
        var count = new Random().Next(1, 3);

        var listItem = new List<string>();

        for(int i = 0; i < count; i++)
        {
            listItem.Add(new Faker().PickRandom(items));
        }

        return items;
    }

    public static List<Dietary> GenerateDietaries()
    {
        var count = new Random().Next(0, 3);

        var dietaries = new List<Dietary>();
        if(count != 0)
        {
            for(int i = 0; i < count; i++)
            {
                dietaries.Add(new Faker().PickRandom<Dietary>());
            }
        }
        return dietaries;
    }
}
