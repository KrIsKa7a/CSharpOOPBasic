﻿using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private const string offset = "  ";

    public string model;
    public Engine engine;
    public int weight;
    public string color;

    public Car(string model, Engine engine, int weight = -1, string color = "n/a")
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendFormat("{0}:\n", this.model);
        sb.Append(this.engine.ToString());
        sb.AppendFormat("{0}Weight: {1}\n", offset, this.weight == -1 ? "n/a" : this.weight.ToString());
        sb.AppendFormat("{0}Color: {1}", offset, this.color);

        return sb.ToString();
    }
}
