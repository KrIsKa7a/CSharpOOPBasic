using System;
using P03.WildFarm.Models.Food;
using P03.WildFarm.Models.Animals;
using System.Collections.Generic;

namespace P03.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();

            string animalInput;
            while ((animalInput = Console.ReadLine()) != "End")
            {
                Animal animal = GetAnimal(animalInput, animals);
                Food food = GetFood();

                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Feed(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Animal GetAnimal(string animalInput, List<Animal> animals)
        {
            var animalTokens = animalInput
                    .Split();
            var type = animalTokens[0];
            var name = animalTokens[1];
            var weight = double.Parse(animalTokens[2]);

            Animal animal = null;

            switch (type)
            {
                case "Owl":
                    var owlWingSize = double.Parse(animalTokens[3]);
                    animal = new Owl(name, weight, owlWingSize);
                    break;
                case "Hen":
                    var henWingSize = double.Parse(animalTokens[3]);
                    animal = new Hen(name, weight, henWingSize);
                    break;
                case "Mouse":
                    var mouseLivingRegion = animalTokens[3];
                    animal = new Mouse(name, weight, mouseLivingRegion);
                    break;
                case "Dog":
                    var dogLivingRegion = animalTokens[3];
                    animal = new Dog(name, weight, dogLivingRegion);
                    break;
                case "Cat":
                    var catLivingRegion = animalTokens[3];
                    var catBreed = animalTokens[4];
                    animal = new Cat(name, weight, catLivingRegion, catBreed);
                    break;
                case "Tiger":
                    var tigerLivingRegion = animalTokens[3];
                    var tigerBreed = animalTokens[4];
                    animal = new Tiger(name, weight, tigerLivingRegion, tigerBreed);
                    break;
                default:
                    throw new InvalidOperationException("Invalid animal type!");
            }

            animals.Add(animal);

            return animal;
        }

        private static Food GetFood()
        {
            var foodTokens = Console.ReadLine()
                    .Split();
            var foodType = foodTokens[0];
            var foodQuantity = int.Parse(foodTokens[1]);

            Food food = null;

            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(foodQuantity);
                    break;
                case "Fruit":
                    food = new Fruit(foodQuantity);
                    break;
                case "Meat":
                    food = new Meat(foodQuantity);
                    break;
                case "Seeds":
                    food = new Seeds(foodQuantity);
                    break;
                default:
                    throw new InvalidOperationException("The food type is invalid!");
            }

            return food;
        }
    }
}
