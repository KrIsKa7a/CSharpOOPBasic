using System;
using System.Collections.Generic;
using System.Text;

public abstract class Drivers
{
    private string name;
    private double totalTime;
    private Cars car;
    private double fuelConsumptionPerKm;
    private double speed;

    protected Drivers(string name, double totalTime, Cars car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = totalTime;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public double TotalTime
    {
        get { return this.totalTime; }
        private set { this.totalTime = value; }
    }

    public Cars Car
    {
        get { return this.car; }
        private set { this.car = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        protected set { this.fuelConsumptionPerKm = value; }
    }

    public double Speed
    {
        get
        {
            return (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        }
        protected set
        {
            this.speed = value;
        }
    }
}
