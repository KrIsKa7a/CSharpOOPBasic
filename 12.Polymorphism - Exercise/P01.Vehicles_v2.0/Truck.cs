using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles_v2._0
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override string Drive(double distance)
        {
            var neededFuel = distance * (this.FuelConsumption + 1.6);

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (amount > this.AvailableSpace)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }

            this.FuelQuantity += amount * 0.95;
        }
    }
}
