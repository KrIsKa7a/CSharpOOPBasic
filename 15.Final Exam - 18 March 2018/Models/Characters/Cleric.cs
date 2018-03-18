using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Interfaces;
using DungeonsAndCodeWizards.Static_data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) 
            : base(name, 50d, 25d, 40, new Backpack(), faction)
        {

        }

        public override double RestHealMultiplier => 0.5d;

        public void Heal(Character character)
        {
            CheckIfBothCharactersAreAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(OutputMessages.HealingEnemy);
            }

            character.ChangeHealth(this.AbilityPoints);
        }
    }
}
