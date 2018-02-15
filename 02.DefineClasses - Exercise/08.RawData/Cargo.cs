using System;
using System.Collections.Generic;
using System.Text;

public class Cargo
{
    private double weight;
    private string type;

    public double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    public Cargo()
    {
        this.weight = 0;
        this.type = string.Empty;
    }

    public Cargo(double weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }
}
