using System;
using System.Collections.Generic;
using System.Text;

public class EnduranceDriver : Drivers
{
    protected EnduranceDriver(string name, double totalTime, Cars car) 
        : base(name, totalTime, car, 1.5)
    {
    }
}
