using System;
using System.Collections.Generic;
using System.Text;
using _01.Vehicles.Interfaces;

namespace _01.Vehicles
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private double fuelQuantity;
        private double fuelCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double fuelCapacity)
        {
            this.FuelCapacity = fuelCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > this.FuelCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; set; }

        public double FuelCapacity
        {
            get { return this.fuelCapacity; }
            set { this.fuelCapacity = value; }
        }

        private double AvailableSpace => this.FuelCapacity - this.FuelQuantity;

        public string Drive(double distance)
        {
            var neededFuel = distance * this.FuelConsumption;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (liters > this.AvailableSpace)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            if (this.GetType() is Truck)
            {
                this.FuelQuantity += liters * 0.95;
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
