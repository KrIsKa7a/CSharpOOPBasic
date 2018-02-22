﻿using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string name;
    private decimal price;

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}