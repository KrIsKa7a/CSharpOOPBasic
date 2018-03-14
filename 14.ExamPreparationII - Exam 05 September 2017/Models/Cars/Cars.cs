using System;
using System.Collections.Generic;
using System.Text;

public class Cars
{
    private const double FUEL_TANK_CAPACITY = 160;

    private int hp;
    private double fuelAmount;
    private Tyres tyre;

    public Cars(int hp, double fuelAmount, Tyres tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            if (value > FUEL_TANK_CAPACITY)
            {
                this.fuelAmount = FUEL_TANK_CAPACITY;
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    public Tyres Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }
}
