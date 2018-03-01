using System;

public class Program
{
    static void Main(string[] args)
    {
        Smartphone smartphone = new Smartphone("Nokia");

        string[] phones = Console.ReadLine().Split(new[] { ' ' });
        foreach (var phone in phones)
        {
            Console.WriteLine(smartphone.CallNumber(phone));
        }

        string[] websites = Console.ReadLine().Split(new[] { ' ' });

        foreach (var website in websites)
        {
            Console.WriteLine(smartphone.BrowseURL(website));
        }
    }
}
