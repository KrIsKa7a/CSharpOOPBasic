using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyres
{
    private string name;
    private double hardness;
    private double degradation;

    protected Tyres(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public double Hardness
    {
        get { return this.hardness; }
        private set { this.hardness = value; }
    }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            this.degradation = value;
        }
    }
}
