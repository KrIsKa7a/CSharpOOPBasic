using System;
using System.Collections.Generic;
using System.Text;

public class PlayerStats
{
    private const int MIN_STAT_VALUE = 0;
    private const int MAX_STAT_VALUE = 100;

    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public PlayerStats(int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    private int Endurance
    {
        get { return this.endurance; }
        set
        {
            ValidateStat("Endurance", value);

            this.endurance = value;
        }
    }

    private int Sprint
    {
        get { return this.sprint; }
        set
        {
            ValidateStat("Sprint", value);

            this.sprint = value;
        }
    }

    private int Dribble
    {
        get { return this.dribble; }
        set
        {
            ValidateStat("Dribble", value);

            this.dribble = value;
        }
    }

    private int Passing
    {
        get { return this.passing; }
        set
        {
            ValidateStat("Passing", value);

            this.passing = value;
        }
    }

    private int Shooting
    {
        get { return this.shooting; }
        set
        {
            ValidateStat("Shooting", value);

            this.shooting = value;
        }
    }

    public double GetAverageStat()
    {
        var averageStat = (this.Endurance + this.Dribble + this.Passing + this.Sprint +
            this.Shooting) / 5.0;

        return averageStat;
    }

    private void ValidateStat(string statName, int value)
    {
        if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
        {
            throw new ArgumentException($"{statName} should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
        }
    }
}
