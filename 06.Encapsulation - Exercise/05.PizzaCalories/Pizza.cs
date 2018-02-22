using System;
using System.Collections.Generic;
using System.Text;

public class Pizza
{
    private const int MIN_LENGHT = 1;
    private const int MAX_LENGHT = 15;
    private const int MIN_TOPPINGS_COUNT = 0;
    private const int MAX_TOPPINGS_COUNT = 10;

    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public Pizza()
    {
        this.toppings = new List<Topping>();
    }

    public Pizza(string name)
        :this()
    {
        this.Name = name;
    }

    public Pizza(string name, Dough dough)
        :this(name)
    {
        this.Dough = dough;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGHT)
            {
                throw new ArgumentException($"Pizza name should be between {MIN_LENGHT} and {MAX_LENGHT} symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        get { return this.dough; }
        set { this.dough = value; }
    }

    public int NumberOfToppings
    {
        get { return this.toppings.Count; }
    }

    public void AddTopping(Topping topping)
    {
        this.toppings.Add(topping);

        if (NumberOfToppings > MAX_TOPPINGS_COUNT)
        {
            throw new ArgumentException($"Number of toppings should be in range [{MIN_TOPPINGS_COUNT}..{MAX_TOPPINGS_COUNT}].");
        }
    }

    public double GetCalories()
    {
        var doughtCalories = this.dough.GetDoughCalories();
        double toppingCalories = 0;

        foreach (var top in toppings)
        {
            toppingCalories += top.CalculateToppingCalories();
        }

        return doughtCalories + toppingCalories;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.GetCalories():f2} Calories.";
    }
}
