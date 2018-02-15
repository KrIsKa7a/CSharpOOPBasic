using System;

class Program
{
    static void Main(string[] args)
    {
        var type = Console.ReadLine();
        
        if (type == "Square")
        {
            var size = int.Parse(Console.ReadLine());
            var square = new Square(size);
            var drawingTools = new DrawingTool(square);
            drawingTools.DrawFigure();
        }
        else if(type == "Rectangle")
        {
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            var rectangle = new Rectangle(width, height);
            var drawingTools = new DrawingTool(rectangle);
            drawingTools.DrawFigure();
        }
    }
}
