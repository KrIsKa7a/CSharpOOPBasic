using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var recntangleCoordinates = Console.ReadLine();

        var rectangle = new Rectangle(recntangleCoordinates);

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            ReadAndCheckCoordinates(rectangle);
        }
    }

    private static void ReadAndCheckCoordinates(Rectangle rectangle)
    {
        var currentPointCoordinates = Console.ReadLine();

        Point point = GetPointFromCoordinates(currentPointCoordinates);

        Console.WriteLine(rectangle.Contains(point));
    }

    private static Point GetPointFromCoordinates(string coordinates)
    {
        var tokens = coordinates
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var x = tokens[0];
        var y = tokens[1];

        var point = new Point(x, y);

        return point;
    }
}
