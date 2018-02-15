using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private List<Pokemon> pokemons;
    private List<Sibling> parents;
    private List<Sibling> childs;
    private Car car;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public List<Sibling> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    public List<Sibling> Childs
    {
        get { return this.childs; }
        set { this.childs = value; }
    }

    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public Person()
    {
        this.company = new Company();
        this.pokemons = new List<Pokemon>();
        this.parents = new List<Sibling>();
        this.childs = new List<Sibling>();
        this.car = new Car();
    }

    public Person(string name, Company company, List<Pokemon> pokemons, 
        List<Sibling> parents, List<Sibling> childs, Car car)
    {
        this.name = name;
        this.company = company;
        this.pokemons = pokemons;
        this.parents = parents;
        this.childs = childs;
        this.car = car;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public void AddParent(Sibling person)
    {
        this.parents.Add(person);
    }

    public void AddChild(Sibling person)
    {
        this.childs.Add(person);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.name);
        sb.AppendLine("Company:");
        if (this.company.CompanyName != null)
        {
            sb.AppendLine(this.company.ToString());
        }
        sb.AppendLine("Car:");
        if (this.car.Model != null)
        {
            sb.AppendLine(this.car.ToString());
        }
        sb.AppendLine("Pokemon:");
        if (this.pokemons.Count > 0)
        {
            sb.AppendLine(String.Join(Environment.NewLine, this.pokemons));
        }
        sb.AppendLine("Parents:");
        if (this.parents.Count > 0)
        {
            sb.AppendLine(String.Join(Environment.NewLine, this.parents));
        }
        sb.AppendLine("Children:");
        if (this.childs.Count > 0)
        {
            sb.AppendLine(String.Join(Environment.NewLine, this.childs));
        }

        return sb.ToString().TrimEnd();
    }
}
