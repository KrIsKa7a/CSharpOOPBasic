using System;

public class Program
{
    static void Main(string[] args)
    {
        var drivername = Console.ReadLine();

        var car = new Ferrari("488-Spider", drivername);

        Console.WriteLine($"{car.Model}/{car.UseBrakes()}/{car.PushGasPedal()}/{car.DriverName}");
    }
}
