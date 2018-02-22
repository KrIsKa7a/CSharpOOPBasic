using System;

public class Program
{
    static void Main(string[] args)
    {
        var l = double.Parse(Console.ReadLine());
        var w = double.Parse(Console.ReadLine());
        var h = double.Parse(Console.ReadLine());

        var box = new Box(l, w, h);
        var surfaceArea = box.CalculateSurfaceArea();
        var laternalSurfaceArea = box.CalculateLateralSurfaceArea();
        var volume = box.CalculateVolume();

        Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        Console.WriteLine($"Lateral Surface Area - {laternalSurfaceArea:f2}");
        Console.WriteLine($"Volume - {volume:f2}");
    }
}
