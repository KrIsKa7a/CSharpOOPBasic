using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private double speed;
    private double power;

    public double Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }

    public double Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public Engine()
    {
        this.speed = 0;
        this.power = 0;
    }

    public Engine(double speed, double power)
    {
        this.speed = speed;
        this.power = power;
    }
}
