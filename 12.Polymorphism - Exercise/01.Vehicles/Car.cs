using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double fuelCapacity) : base(fuelQuantity, fuelConsumption, fuelCapacity){ }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption + 0.9;
            }
            set
            {
                base.FuelConsumption = value;
            }
        }
    }
}
