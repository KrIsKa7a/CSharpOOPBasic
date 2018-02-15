using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private string model;
    private double power;
    private string displacment;
    private string efficiency;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public string Displacement
    {
        get { return this.displacment; }
        set { this.displacment = value; }
    }

    public string Efficiency
    {
        get { return this.efficiency; }
        set { this.efficiency = value; }
    }

    public Engine(string model, double power, string displacment = "n/a", 
        string efficiency = "n/a")
    {
        this.model = model;
        this.power = power;
        this.displacment = displacment;
        this.efficiency = efficiency;
    }
}
