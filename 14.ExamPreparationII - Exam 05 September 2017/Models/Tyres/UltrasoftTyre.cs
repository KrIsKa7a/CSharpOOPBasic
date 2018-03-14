using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyres
{
    private double grip;

    protected UltrasoftTyre(double hardness) 
        : base("Ultrasoft", hardness)
    {

    }

    public double Grip
    {
        get { return this.grip; }
        private set { this.grip = value; }
    }

    public override double Degradation
    {
        get { return base.Degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException();
            }

            base.Degradation = value;
        }
    }
}
