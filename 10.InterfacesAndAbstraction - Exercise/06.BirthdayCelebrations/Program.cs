using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var allThingAsBirthdable = new List<IBirthdate>();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            ParseInput(allThingAsBirthdable, input);
        }

        var wantedYear = int.Parse(Console.ReadLine());

        var filtered = allThingAsBirthdable
            .Where(t => t.BirthDate.Year == wantedYear)
            .ToList();

        PrintFilteredDates(filtered);
    }

    private static void PrintFilteredDates(List<IBirthdate> filtered)
    {
        foreach (var thing in filtered)
        {
            var birthDate = thing.BirthDate;

            Console.WriteLine($"{birthDate.Day:d2}/{birthDate.Month:d2}/{birthDate.Year}");
        }
    }

    private static void ParseInput(List<IBirthdate> allThingAsBirthdable, string input)
    {
        var inputTokens = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var type = inputTokens[0];

        if (type == "Citizen")
        {
            var name = inputTokens[1];
            var age = int.Parse(inputTokens[2]);
            var id = inputTokens[3];
            var birthDate = DateTime.ParseExact(inputTokens[4], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);

            var citizen = new Citizen(name, age, id, birthDate);

            allThingAsBirthdable.Add(citizen);
        }
        else if (type == "Pet")
        {
            var name = inputTokens[1];
            var birthDate = DateTime.ParseExact(inputTokens[2], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);

            var pet = new Pet(name, birthDate);

            allThingAsBirthdable.Add(pet);
        }
    }
}
