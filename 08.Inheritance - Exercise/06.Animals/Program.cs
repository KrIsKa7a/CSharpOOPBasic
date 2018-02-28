using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var animals = new List<Animal>();

        string animalType;

        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                var petArgs = Console.ReadLine()
                        .Split();

                var name = petArgs[0];
                var ageString = petArgs[1];

                int age = ValidateAge(ageString);

                var gender = "";

                if (petArgs.Length >= 3)
                {
                    gender = petArgs[2];
                }

                AddAnimal(animals, animalType, name, age, gender);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void AddAnimal(List<Animal> animals, string animalType, string name, int age, string gender)
    {
        switch (animalType)
        {
            case "Dog":
                var dog = new Dog(name, age, gender);
                animals.Add(dog);
                break;
            case "Cat":
                var cat = new Cat(name, age, gender);
                animals.Add(cat);
                break;
            case "Frog":
                var frog = new Frog(name, age, gender);
                animals.Add(frog);
                break;
            //It may be kittenS
            case "Kitten":
                var kitten = new Kitten(name, age);
                animals.Add(kitten);
                break;
            case "Tomcat":
                var tomcat = new Tomcat(name, age);
                animals.Add(tomcat);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }
    }

    private static int ValidateAge(string ageString)
    {
        int age;

        bool hasParsed = int.TryParse(ageString, out age);

        if (!hasParsed)
        {
            throw new ArgumentException("Invalid input!");
        }

        return age;
    }
}
