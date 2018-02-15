using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public string Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public Car(string model, Engine engine, string weight = "n/a", 
        string color = "n/a")
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.model}:");
        sb.AppendLine($"{new string(' ', 2)}{this.engine.Model}:");
        sb.AppendLine($"{new string(' ', 4)}Power: {this.engine.Power}");
        sb.AppendLine($"{new string(' ', 4)}Displacement: {this.engine.Displacement}");
        sb.AppendLine($"{new string(' ', 4)}Efficiency: {this.engine.Efficiency}");
        sb.AppendLine($"{new string(' ', 2)}Weight: {this.weight}");
        sb.Append($"{new string(' ', 2)}Color: {this.color}");

        return sb.ToString();
    }
}
