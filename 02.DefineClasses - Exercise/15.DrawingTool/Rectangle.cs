using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    private int width;
    private int height;

    public int Width
    {
        get{ return this.width; }
        set { this.width = value; }
    }

    public int Height
    {
        get { return this.height; }
        set { this.width = value; }
    }

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        Console.WriteLine($"|{new string('-', width)}|");

        for (int i = 0; i < this.height - 2; i++)
        {
            Console.WriteLine($"|{ new string(' ', width)}|");
        }

        Console.WriteLine($"|{new string('-', width)}|");
    }
}
