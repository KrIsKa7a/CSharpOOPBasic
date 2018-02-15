using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var trainers = new List<Trainer>();

        while (input != "Tournament")
        {
            var tokens = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = tokens[0];

            Trainer currentTrainer;
            var currentPokemon = new Pokemon(tokens[1], tokens[2], 
                double.Parse(tokens[3]));

            if (trainers.Any(t => t.Name == name))
            {
                currentTrainer = trainers.First(t => t.Name == name);
                currentTrainer.AddPokemon(currentPokemon);
            }
            else
            {
                currentTrainer = new Trainer(name);
                currentTrainer.AddPokemon(currentPokemon);
                trainers.Add(currentTrainer);
            }

            input = Console.ReadLine();
        }

        var command = Console.ReadLine();

        while (command != "End")
        {
            for(int i = 0; i < trainers.Count; i++)
            {
                var trainer = trainers[i];

                if (trainer.Pokemons.Any(p => p.Element == command))
                {
                    trainer.Badgets += 1;
                }
                else
                {
                    for (int j = 0; j < trainer.Pokemons.Count; j++)
                    {
                        var currentPokemon = trainer.Pokemons[j];

                        if (currentPokemon.Health - 10 <= 0)
                        {
                            trainer.Pokemons.RemoveAt(j);
                        }
                        else
                        {
                            trainer.Pokemons[j].Health -= 10;
                        }
                    }
                }
            }

            command = Console.ReadLine();
        }

        trainers = trainers
            .OrderByDescending(t => t.Badgets)
            .ToList();

        foreach (var trainer in trainers)
        {
            Console.WriteLine(trainer);
        }
    }
}
