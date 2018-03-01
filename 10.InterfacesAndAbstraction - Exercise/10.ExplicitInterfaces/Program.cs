using System;

public class Program
{
    static void Main(string[] args)
    {
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var inputArgs = input
                .Split();

            var name = inputArgs[0];
            var country = inputArgs[1];
            var age = int.Parse(inputArgs[2]);

            IPerson person = new Citizen(name, country, age);
            IResident resident = new Citizen(name, country, age);

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());
        }
    }
}
