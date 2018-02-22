using System;

public class Program
{
    static void Main(string[] args)
    {
        var pizzaName = Console.ReadLine().Split()[1];
        var doughInfo = Console.ReadLine().Split();
        var doughType = doughInfo[1];
        var bakeTech = doughInfo[2];
        var doughWeight = double.Parse(doughInfo[3]);

        try
        {
            var pizza = new Pizza(pizzaName);
            var dough = new Dough(doughType, bakeTech, doughWeight);
            pizza.Dough = dough;

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                AddToppings(pizza, command);
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void AddToppings(Pizza pizza, string command)
    {
        var tokens = command
                        .Split();
        var topType = tokens[1];
        var topWeight = double.Parse(tokens[2]);
        var topping = new Topping(topType, topWeight);

        pizza.AddTopping(topping);
    }
}
