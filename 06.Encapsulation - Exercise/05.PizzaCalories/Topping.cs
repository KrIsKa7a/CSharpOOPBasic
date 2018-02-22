using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;
    private const int BASE_MULTIPLIER = 2;

    private Dictionary<string, double> validToppingTypes =
        new Dictionary<string, double>
        {
            ["meat"] = 1.2,
            ["veggies"] = 0.8,
            ["cheese"] = 1.1,
            ["sauce"] = 0.9
        };

    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get { return this.type; }
        private set
        {
            if (!validToppingTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.type = value;
        }
    }

    public double Weight
    {
        get { return this.weight; }
        private set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }

            this.weight = value;
        }
    }

    public double CalculateToppingCalories()
    {
        var calories = BASE_MULTIPLIER * this.Weight *
            validToppingTypes[this.Type.ToLower()];

        return calories;
    }
}
