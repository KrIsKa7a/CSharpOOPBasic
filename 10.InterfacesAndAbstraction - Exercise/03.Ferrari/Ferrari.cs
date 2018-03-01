using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : IDriveable
{
    private string model;
    private string driverName;

    public Ferrari(string model, string driverName)
    {
        this.Model = model;
        this.DriverName = driverName;
    }

    public string Model
    {
        get { return this.model; }
        private set { this.model = value; }
    }

    public string DriverName
    {
        get { return this.driverName; }
        set { this.driverName = value; }
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }
}
