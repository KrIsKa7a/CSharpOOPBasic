using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string input;

        var allInvasitors = new List<IIdentifiable>();

        while ((input = Console.ReadLine()) != "End")
        {
            ParseInput(input, allInvasitors);
        }

        var badId = Console.ReadLine();

        allInvasitors
            .Where(rc => rc.Id.EndsWith(badId))
            .ToList()
            .ForEach(rc => Console.WriteLine(rc.Id));
    }

    private static void ParseInput(string input, List<IIdentifiable> allInvasitors)
    {
        var inputTokens = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (inputTokens.Length == 2)
        {
            var model = inputTokens[0];
            var id = inputTokens[1];

            var robot = new Robot(model, id);

            allInvasitors.Add(robot);
        }
        else if (inputTokens.Length == 3)
        {
            var name = inputTokens[0];
            var age = int.Parse(inputTokens[1]);
            var id = inputTokens[2];

            var citizen = new Citizen(name, age, id);

            allInvasitors.Add(citizen);
        }
    }
}
