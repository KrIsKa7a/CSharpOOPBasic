using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var cats = new List<Cat>();

        var command = Console.ReadLine();

        while (command != "End")
        {
            var catArgs = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var breed = catArgs[0];
            var name = catArgs[1];
            var parameter = double.Parse(catArgs[2]);

            var currentCat = new Cat(breed, name, parameter);

            cats.Add(currentCat);

            command = Console.ReadLine();
        }

        var wantedCatName = Console.ReadLine();

        var wantedCat = cats.First(c => c.Name == wantedCatName);

        Console.WriteLine(wantedCat);
    }
}
