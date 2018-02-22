using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var teams = new List<Team>();

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            var commandArgs = command
                .Split(';');
            try
            {
                ParseCommand(teams, commandArgs);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static void ParseCommand(List<Team> teams, string[] commandArgs)
    {
        var typeOfCommand = commandArgs[0];

        if (typeOfCommand == "Team")
        {
            AddTeam(teams, commandArgs);
        }
        else if (typeOfCommand == "Add")
        {
            AddPlayerToATeam(teams, commandArgs);
        }
        else if (typeOfCommand == "Remove")
        {
            RemovePlayerFromTeam(teams, commandArgs);
        }
        else if (typeOfCommand == "Rating")
        {
            ShowRatingOfTeam(teams, commandArgs);
        }
    }

    private static void ShowRatingOfTeam(List<Team> teams, string[] commandArgs)
    {
        var teamName = commandArgs[1];

        if (!teams.Any(t => t.Name == teamName))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }

        var currentTeam = teams.First(t => t.Name == teamName);

        Console.WriteLine(currentTeam);
    }

    private static void RemovePlayerFromTeam(List<Team> teams, string[] commandArgs)
    {
        var teamName = commandArgs[1];

        if (!teams.Any(t => t.Name == teamName))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }

        var playerName = commandArgs[2];

        var currentTeam = teams.First(t => t.Name == teamName);

        currentTeam.RemovePlayer(playerName);
    }

    private static void AddPlayerToATeam(List<Team> teams, string[] commandArgs)
    {
        var teamName = commandArgs[1];

        if (string.IsNullOrWhiteSpace(teamName))
        {
            throw new ArgumentException("A name should not be empty.");
        }

        if (!teams.Any(t => t.Name == teamName))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }

        var playerName = commandArgs[2];
        var endurance = int.Parse(commandArgs[3]);
        var sprint = int.Parse(commandArgs[4]);
        var dribble = int.Parse(commandArgs[5]);
        var passing = int.Parse(commandArgs[6]);
        var shooting = int.Parse(commandArgs[7]);

        var currentStat = new PlayerStats(endurance, sprint, dribble, passing, shooting);
        var currentPlayer = new Player(playerName, currentStat);
        var currentTeam = teams.First(t => t.Name == teamName);
        currentTeam.AddPlayer(currentPlayer);
    }

    private static void AddTeam(List<Team> teams, string[] commandArgs)
    {
        var team = new Team(commandArgs[1]);
        teams.Add(team);
    }
}
