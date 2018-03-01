using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var toAdd = Console.ReadLine()
            .Split();
        var toRemoveCount = int.Parse(Console.ReadLine());

        var adc = new AddCollection();
        var adrc = new AddRemoveCollection();
        var mylist = new MyList();

        PrintAdd(toAdd, adc);
        PrintAdd(toAdd, adrc);
        PrintAdd(toAdd, mylist);

        PrintRemove(toRemoveCount, adrc);
        PrintRemove(toRemoveCount, mylist);
    }

    private static void PrintRemove(int toRemoveCount, IAddRemoveCollection adrc)
    {
        var removed = new List<string>();

        for (int i = 0; i < toRemoveCount; i++)
        {
            removed.Add(adrc.Remove());
        }

        Console.WriteLine(String.Join(" ", removed));
    }

    private static void PrintAdd(string[] toAdd, IAddCollection adc)
    {
        var indexes = new List<int>();

        foreach (var item in toAdd)
        {
            indexes.Add(adc.Add(item));
        }

        Console.WriteLine(String.Join(" ", indexes));
    }
}
