using System;
using System.Collections.Generic;
using System.Text;

public class Tire
{
    private double pressure;
    private double age;

    public double Pressure
    {
        get { return this.pressure; }
        set { this.pressure = value; }
    }

    public double Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Tire(double pressure, double age)
    {
        this.pressure = pressure;
        this.age = age;
    }
}

