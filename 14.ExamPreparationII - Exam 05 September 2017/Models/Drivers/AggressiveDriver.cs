using System;
using System.Collections.Generic;
using System.Text;

public class AggressiveDriver : Drivers
{
    protected AggressiveDriver(string name, double totalTime, Cars car) 
        : base(name, totalTime, car, 2.7)
    {
        this.Speed += this.Speed * 1.3;
    }
}
