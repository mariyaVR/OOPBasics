using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<Trainer> Trainers = new List<Trainer>();
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        while (input[0] != "Tournament")
        {
            string trainerName = input[0];
            string pokemonName = input[1];
            string pokemonElement = input[2];
            int pokemonHealth = int.Parse(input[3]);

            Pokemon currPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            if (!Trainers.Any(t => t.name == trainerName))
            {
                Trainers.Add(new Trainer(trainerName, 0, new List<Pokemon>()));
            }

            var currTrainer = Trainers.Where(t => t.name == trainerName).FirstOrDefault();
            currTrainer.pokemon.Add(currPokemon);

            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        var command = Console.ReadLine();
        while (command != "End")
        {
            var result = Trainers.Where(t => t.pokemon.Any(s => s.element == command));
            foreach (var trainer in Trainers)
            {
                if (trainer.pokemon.Any(p => p.element == command))
                {
                    trainer.badges++;
                }
                else
                {
                    for (int i = trainer.pokemon.Count - 1; i >= 0; i--)
                    {
                        trainer.pokemon[i].health -= 10;
                        if (trainer.pokemon[i].health <= 0)
                        {
                            trainer.pokemon.RemoveAt(i);
                        }
                    }
                }
            }

            command = Console.ReadLine();
        }

        var print = Trainers.OrderByDescending(t => t.badges);
        foreach (var trainer in print)
        {
            Console.WriteLine(trainer.name + " " + trainer.badges + " " + trainer.pokemon.Count);
        }
    }
}

