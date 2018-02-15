using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var persons = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var currentPerson = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var person = new Person(currentPerson[0], int.Parse(currentPerson[1]));

            persons.Add(person);
        }

        persons = persons
            .Where(p => p.Age > 30)
            .OrderBy(p => p.Name)
            .ToList();

        foreach (var person in persons)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
