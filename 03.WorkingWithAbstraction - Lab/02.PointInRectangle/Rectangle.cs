using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Rectangle
{
    private Point topLeftPoint;
    private Point bottomRightPoint;

    public Rectangle(string coordinates)
    {
        var tokens = coordinates
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        this.topLeftPoint = new Point(tokens[0], tokens[1]);
        this.bottomRightPoint = new Point(tokens[2], tokens[3]);
    }

    public bool Contains(Point point)
    {
        var containsPoint = (point.X >= this.topLeftPoint.X && point.X <= this.bottomRightPoint.X) && (point.Y <= this.bottomRightPoint.Y && point.Y >= this.topLeftPoint.Y);

        return containsPoint;
    }
}
