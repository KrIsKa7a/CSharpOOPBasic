using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionForKilometer;
    private double distanceTravelled;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
    }

    public double FuelConsumptionForKilometer
    {
        get { return this.fuelConsumptionForKilometer; }
    }

    public double DistanceTravelled
    {
        get { return this.distanceTravelled; }
    }

    public Car(string model, double fuelAmount, double fuelConsumptionForKilometer)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumptionForKilometer = fuelConsumptionForKilometer;
        this.distanceTravelled = 0;
    }

    public void MoveCar(double amountOfKilometers)
    {
        var neededFuel = amountOfKilometers * this.fuelConsumptionForKilometer;

        if (neededFuel > this.fuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            this.distanceTravelled += amountOfKilometers;
            this.fuelAmount -= neededFuel;
        }
    }

    public override string ToString()
    {
        return $"{this.model} {this.fuelAmount:f2} {this.distanceTravelled}";
    }
}
