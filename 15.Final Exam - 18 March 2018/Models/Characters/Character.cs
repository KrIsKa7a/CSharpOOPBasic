using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;
using DungeonsAndCodeWizards.Static_data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = this.BaseHealth;
            this.BaseArmor = armor;
            this.Armor = this.BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(OutputMessages.EmptyName);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health { get; private set; }

        public double BaseArmor { get; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public Faction Faction { get; }

        public bool IsAlive { get; private set; }

        public virtual double RestHealMultiplier { get; }

        public void TakeDamage(double hitPoints)
        {
            CheckIfCurrentCharacterIsAlive();

            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                var leftHitPoints = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= leftHitPoints;
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
                //May be added
                this.Health = 0;
            }
        }

        public void Rest()
        {
            CheckIfCurrentCharacterIsAlive();

            this.Health += this.BaseHealth * this.RestHealMultiplier;

            if (this.Health > this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }
        }

        public void UseItem(Item item)
        {
            CheckIfCurrentCharacterIsAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckIfBothCharactersAreAlive(character);

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckIfBothCharactersAreAlive(character);

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            CheckIfCurrentCharacterIsAlive();

            this.Bag.AddItem(item);
        }

        public void ChangeHealth(double amount)
        {
            this.Health += amount;

            if (this.Health > this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }
        }

        public void RestoreBaseArmor()
        {
            this.Armor = this.BaseArmor;
        }

        protected void CheckIfCurrentCharacterIsAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.NotAliveCharacter);
            }
        }

        protected void CheckIfBothCharactersAreAlive(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.NotAliveCharacter);
            }
        }

        public override string ToString()
        {
            var status = this.IsAlive ? "Alive" : "Dead";
            
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}
