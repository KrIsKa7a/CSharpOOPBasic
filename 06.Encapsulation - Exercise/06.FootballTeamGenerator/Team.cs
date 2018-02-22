using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;
    private List<Player> players;
    private double rating;

    public Team()
    {
        this.players = new List<Player>();
    }

    public Team(string name)
        :this()
    {
        this.Name = name;
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    private double Rating
    {
        get { return CalculateRating(); }
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (!this.players.Any(p => p.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }

        var player = this.players.First(p => p.Name == playerName);

        this.players.Remove(player);
    }

    public double CalculateRating()
    {
        if (this.players.Count == 0)
        {
            return 0;
        }

        var rating = this.players.Select(p => p.SkillLevel).Average();

        return rating;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Rating:f0}";
    }
}
