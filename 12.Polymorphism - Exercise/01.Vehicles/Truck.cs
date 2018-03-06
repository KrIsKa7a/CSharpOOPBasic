using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double fuelCapacity) : base(fuelQuantity, fuelConsumption, fuelCapacity) { }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption + 1.6;
            }
            set
            {
                base.FuelConsumption = value;
            }
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
        }
    }
}
