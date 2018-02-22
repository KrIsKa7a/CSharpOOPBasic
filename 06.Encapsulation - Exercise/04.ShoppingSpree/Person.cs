using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag; 

    public Person()
    {
        this.bag = new List<Product>();
    }

    public Person(string name, decimal money)
        :this()
    {
        this.Name = name;
        this.Money = money;
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

    public decimal Money
    {
        get { return this.money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public IReadOnlyCollection<Product> Bag
    {
        get { return this.bag; }
    }

    public string TryBuyProduct(Product product)
    {
        if (this.Money < product.Price)
        {
            return $"{this.Name} can't afford {product.Name}";
        }

        this.Money -= product.Price;
        this.bag.Add(product);

        return $"{this.Name} bought {product.Name}";
    }

    public override string ToString()
    {
        if (this.Bag.Count > 0)
        {
            return $"{this.Name} - {String.Join(", ", this.Bag)}";
        }
        else
        {
            return $"{this.Name} - Nothing bought";
        }
    }
}
