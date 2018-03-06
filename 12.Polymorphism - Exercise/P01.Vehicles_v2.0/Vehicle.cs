using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles_v2._0
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        protected double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        protected double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        protected double TankCapacity
        {
            get { return this.tankCapacity; }
            set { this.tankCapacity = value; }
        }

        protected double AvailableSpace => this.TankCapacity - this.FuelQuantity;

        public abstract string Drive(double distance);

        public abstract void Refuel(double amount);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
