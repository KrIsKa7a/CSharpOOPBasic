using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 200;
    private const double BASE_MULTIPLIER = 2.0; 

    private Dictionary<string, double> validFlourTypes =
        new Dictionary<string, double>
        {
            ["white"] = 1.5,
            ["wholegrain"] = 1.0
        };
    private Dictionary<string, double> validBakingTechniqueTypes =
        new Dictionary<string, double>
        {
            ["crispy"] = 0.9,
            ["chewy"] = 1.1,
            ["homemade"] = 1.0
        };

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get { return this.flourType; }
        private set
        {
            if (!validFlourTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return this.bakingTechnique; }
        private set
        {
            if (!validBakingTechniqueTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    public double Weight
    {
        get { return this.weight; }
        private set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }

            this.weight = value;
        }
    }

    public double GetDoughCalories()
    {
        var calories = BASE_MULTIPLIER * this.Weight *
            validFlourTypes[this.FlourType.ToLower()] *
            validBakingTechniqueTypes[this.BakingTechnique.ToLower()];

        return calories;
    }
}
