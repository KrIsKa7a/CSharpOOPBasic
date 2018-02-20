using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        AddPerson(lines, persons);

        var team = new Team("Uragan Palatovo");
        foreach (var player in persons)
        {
            team.AddPlayer(player);
        }

        Console.WriteLine("First team has {0} players.", 
            team.FirstTeam.Count);
        Console.WriteLine("Reserve team has {0} players.",
            team.ReserveTeam.Count);
    }

    private static void AddPerson(int lines, List<Person> persons)
    {
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            try
            {
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}
