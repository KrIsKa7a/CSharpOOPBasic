using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    private double Length
    {
        get { return this.length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }

            this.length = value;
        }
    }

    private double Width
    {
        get { return this.width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }

            this.width = value;
        }
    }

    private double Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public double CalculateSurfaceArea()
    {
        var surfaceArea = (2 * this.Length * this.Width) +
            (2 * this.Height * this.Length) + (2 * this.Width * this.Height);

        return surfaceArea;
    }

    public double CalculateLateralSurfaceArea()
    {
        var laternalSurfaceArea = (2 * this.Length * this.Height) +
            (2 * this.Width * this.Height);

        return laternalSurfaceArea;
    }

    public double CalculateVolume()
    {
        var volume = this.Length * this.Height * this.Width;

        return volume;
    }
}
