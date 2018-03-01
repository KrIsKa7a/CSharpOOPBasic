using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var all = new List<IBuyer>();
        AddRebelsAndCitizens(n, all);

        string name;


        while ((name = Console.ReadLine()) != "End")
        {
            var current = all
                .FirstOrDefault(t => t.Name == name);

            if (current == null)
            {
                continue;
            }

            current.BuyFood();
        }

        var totalFood = 0;

        foreach (var thing in all)
        {
            totalFood += thing.Food;
        }

        Console.WriteLine(totalFood);
    }

    private static void AddRebelsAndCitizens(int n, List<IBuyer> all)
    {
        for (int i = 0; i < n; i++)
        {
            var inputTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (inputTokens.Length == 4)
            {
                var name = inputTokens[0];
                var age = int.Parse(inputTokens[1]);
                var id = inputTokens[2];
                var birthDate = DateTime.ParseExact(inputTokens[3], "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);

                var citizen = new Citizen(name, age, id, birthDate);

                all.Add(citizen);
            }
            else if (inputTokens.Length == 3)
            {
                var name = inputTokens[0];
                var age = int.Parse(inputTokens[1]);
                var group = inputTokens[2];

                var rebel = new Rebel(name, age, group);

                all.Add(rebel);
            }
        }
    }
}
