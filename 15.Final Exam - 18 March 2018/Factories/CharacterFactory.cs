using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Static_data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionName, string type, string name)
        {
            bool parsed = Enum.TryParse(typeof(Faction), factionName, out object result);

            if (!parsed)
            {
                throw new ArgumentException($"Invalid faction \"{factionName}\"!");
            }

            var faction = Enum.Parse<Faction>(factionName);

            switch (type)
            {
                case "Warrior":
                    return new Warrior(name, faction);
                case "Cleric":
                    return new Cleric(name, faction);
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }
        }
    }
}
