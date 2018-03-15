using System;
using System.Collections.Generic;
using System.Text;

public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car) 
        : base(name, car/*, 2.7*/)
    {
        this.Speed += this.Speed * 1.3;
        this.FuelConsumptionPerKm = 2.7;
    }
}
