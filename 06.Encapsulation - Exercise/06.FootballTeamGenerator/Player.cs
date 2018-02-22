using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    private string name;
    private PlayerStats stats;

    public Player(string name, PlayerStats stats)
    {
        this.Name = name;
        this.Stats = stats;
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

    public PlayerStats Stats
    {
        get { return this.stats; }
        private set { this.stats = value; }
    }

    public double SkillLevel
    {
        get { return this.stats.GetAverageStat(); }
    }
}
