using System;


class Program
{
    static void Main(string[] args)
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var dateModifier = new DateModifier();

        var difference = dateModifier.CalculateDifference(firstDate, secondDate);

        Console.WriteLine(difference);
    }
}
