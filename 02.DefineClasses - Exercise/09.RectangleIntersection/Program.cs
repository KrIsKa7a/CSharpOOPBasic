using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var nm = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var n = nm[0];
        var m = nm[1];

        var rectangles = new List<Rectangle>();

        for (int i = 0; i < n; i++)
        {
            AddRectangles(rectangles);
        }

        for (int i = 0; i < m; i++)
        {
            var intersectIds = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstRectangleId = intersectIds[0];
            var secondRectangleId = intersectIds[1];

            var firstRectangle = rectangles
                .First(r => r.Id == firstRectangleId);
            var secondRectangle = rectangles
                .First(r => r.Id == secondRectangleId);

            var hasIntersection = firstRectangle.Intersect(secondRectangle);

            Console.WriteLine(hasIntersection.ToString().ToLower());
        }
    }

    private static void AddRectangles(List<Rectangle> rectangles)
    {
        var rectArgs = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var currentRectangle = new Rectangle(rectArgs[0],
            double.Parse(rectArgs[1]), double.Parse(rectArgs[2]),
            double.Parse(rectArgs[3]), double.Parse(rectArgs[4]));

        rectangles.Add(currentRectangle);
    }
}
