using System;
using System.Collections.Generic;
using System.Text;

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get { return this.radius; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The radius lenght must be positive!");
            }

            this.radius = value;
        }
    }

    public override double CalculateArea()
    {
        var area = Math.PI * this.Radius * this.Radius;

        return area;
    }

    public override double CalculatePerimeter()
    {
        var perimeter = 2 * Math.PI * this.Radius;

        return perimeter;
    }

    public override string Draw()
    {
        return base.Draw() + this.GetType().Name;
    }
}
