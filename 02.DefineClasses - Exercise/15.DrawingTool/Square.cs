using System;
using System.Collections.Generic;
using System.Text;

public class Square
{
    private int size;

    public int Size
    {
        get { return this.size; }
        set { this.size = value; }
    }

    public Square(int size)
    {
        this.size = size;
    }

    public void Draw()
    {
        Console.WriteLine($"|{new string('-', this.size)}|");

        for (int i = 0; i < this.size - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', this.size)}|");
        }

        Console.WriteLine($"|{new string('-', this.size)}|");
    }
}
