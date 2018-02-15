using System;
using System.Collections.Generic;
using System.Text;

public class Cat
{
    private string breed;
    private string name;
    private double parameter;

    public string Breed
    {
        get { return this.breed; }
        set { this.breed = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public double Parameter
    {
        get { return this.parameter; }
        set { this.parameter = value; }
    }

    public Cat(string breed, string name, double parameter)
    {
        this.breed = breed;
        this.name = name;
        this.parameter = parameter;
    }

    public override string ToString()
    {
        if (this.breed == "Cymric")
        {
            return $"{this.breed} {this.name} {this.parameter:f2}";
        }
        else
        {
            return $"{this.breed} {this.name} {this.parameter}";
        }
    }
}
