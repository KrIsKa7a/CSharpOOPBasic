using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double topLeftPointX;
    private double topLeftPointY;

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }
    
    public double X
    {
        get { return this.topLeftPointX; }
        set { this.topLeftPointX = value; }
    }

    public double Y
    {
        get { return this.topLeftPointY; }
        set { this.topLeftPointY = value; }
    }

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.topLeftPointX = x;
        this.topLeftPointY = y;
    }

    public bool Intersect(Rectangle rectangle)
    {
        bool NoIntersect = (this.topLeftPointX + this.width < rectangle.X) ||
            (rectangle.X + rectangle.Width < this.X) ||
            (this.topLeftPointY + this.Height < rectangle.Y) ||
            (rectangle.Y + rectangle.Height < this.topLeftPointY);

        if (NoIntersect)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
