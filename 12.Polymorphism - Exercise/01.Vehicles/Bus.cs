using System;
using System.Collections.Generic;
using System.Text;
using _01.Vehicles.Interfaces;

namespace _01.Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double fuelCapacity) : base(fuelQuantity, fuelConsumption, fuelCapacity){ }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption + 1.4;
            }
        }

        public string DriveEmpty(double distance)
        {
            var neededFuel = distance * (this.FuelConsumption - 1.4);

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}
