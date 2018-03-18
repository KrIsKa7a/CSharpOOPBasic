using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Interfaces;
using DungeonsAndCodeWizards.Static_data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) 
            : base(name, 100d, 50d, 40d, new Satchel(), faction)
        {

        }

        public void Attack(Character character)
        {
            CheckIfBothCharactersAreAlive(character);

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(OutputMessages.AttackSelf);
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException(String.Format(OutputMessages.FriendlyFire, this.Faction));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
