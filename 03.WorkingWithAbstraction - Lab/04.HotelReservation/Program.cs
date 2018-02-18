using System;

public class Program
{
    static void Main(string[] args)
    {
        var command = Console.ReadLine();

        var priceCalc = new PriceCalculator(command);

        Console.WriteLine($"{priceCalc.CalculatePrice():f2}");
    }
}
