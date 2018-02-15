using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var persones = new List<Person>();

        var command = Console.ReadLine();

        while (command != "End")
        {
            var cmdArgs = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = cmdArgs[0];
            var type = cmdArgs[1];

            var currentPerson = new Person();

            if (persones.Any(p => p.Name == name))
            {
                currentPerson = persones.First(p => p.Name == name);
            }
            else
            {
                currentPerson.Name = name;
                persones.Add(currentPerson);
            }

            if (type == "company")
            {
                var company = new Company(cmdArgs[2], cmdArgs[3], 
                    double.Parse(cmdArgs[4]));
                currentPerson.Company = company;
            }
            else if (type == "pokemon")
            {
                var pokemon = new Pokemon(cmdArgs[2], cmdArgs[3]);
                currentPerson.AddPokemon(pokemon);
            }
            else if (type == "parents")
            {
                var person = new Sibling(cmdArgs[2], cmdArgs[3]);
                currentPerson.AddParent(person);
            }
            else if (type == "children")
            {
                var person = new Sibling(cmdArgs[2], cmdArgs[3]);
                currentPerson.AddChild(person);
            }
            else if (type == "car")
            {
                var car = new Car(cmdArgs[2], double.Parse(cmdArgs[3]));
                currentPerson.Car = car;
            }

            command = Console.ReadLine();
        }

        var wantedPersonName = Console.ReadLine();

        var wantedPerson = persones.First(p => p.Name == wantedPersonName);

        Console.WriteLine(wantedPerson);
    }
}
