using System;
using System.Collections.Generic;
using System.Text;

public class Trainer
{
    private string name;
    private int badgets;
    private List<Pokemon> pokemons;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Badgets
    {
        get { return this.badgets; }
        set { this.badgets = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public Trainer()
    {
        this.badgets = 0;
        this.pokemons = new List<Pokemon>();
    }

    public Trainer(string name) : this()
    {
        this.name = name;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public override string ToString()
    {
        return $"{this.name} {this.badgets} {this.pokemons.Count}";
    }
}
