using System;
using System.Collections.Generic;
using System.Text;

public class Point
{
    private int x;
    private int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X
    {
        get { return this.x; }
        private set { this.x = value; }
    }

    public int Y
    {
        get { return this.y; }
        private set { this.y = value; }
    }
}
