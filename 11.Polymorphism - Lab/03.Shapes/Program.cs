using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            var shapes = new List<Shape>()
            {
                new Rectangle(-33, 5),
                new Rectangle(6, 7),
                new Circle(4),
                new Rectangle(4, 4)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.Draw());
            }
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}
