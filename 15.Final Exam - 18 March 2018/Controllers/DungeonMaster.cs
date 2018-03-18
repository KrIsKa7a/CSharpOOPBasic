using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Interfaces;
using DungeonsAndCodeWizards.Models.Items;
using DungeonsAndCodeWizards.Static_data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Controllers
{
    public class DungeonMaster
    {
        private List<Character> party;
        private Stack<Item> itemPool;
        private int lastSurvivorRounds;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemPool = new Stack<Item>();
            this.lastSurvivorRounds = 0;
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var factionName = args[0];
            var characterType = args[1];
            var name = args[2];

            Character character = this.characterFactory.CreateCharacter(factionName, characterType, name);

            party.Add(character);

            return String.Format($"{name} joined the party!");
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);

            this.itemPool.Push(item);

            return String.Format($"{itemName} added to pool.");
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            if (!this.party.Any(c => c.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var character = this.party.First(c => c.Name == characterName);
            var item = this.itemPool.Pop();

            character.ReceiveItem(item);

            return String.Format($"{characterName} picked up {item.GetType().Name}!");
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            if (!this.party.Any(c => c.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            var character = this.party.First(c => c.Name == characterName);
            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return String.Format($"{character.Name} used {itemName}.");
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var recieverName = args[1];
            var itemName = args[2];

            if (!this.party.Any(c => c.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            if (!this.party.Any(c => c.Name == recieverName))
            {
                throw new ArgumentException($"Character {recieverName} not found!");
            }

            var giver = this.party.First(c => c.Name == giverName);
            var reciever = this.party.First(c => c.Name == recieverName);

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, reciever);

            return String.Format($"{giverName} used {itemName} on {recieverName}.");
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var recieverName = args[1];
            var itemName = args[2];

            if(!this.party.Any(c => c.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            if (!this.party.Any(c => c.Name == recieverName))
            {
                throw new ArgumentException($"Character {recieverName} not found!");
            }

            var giver = this.party.First(c => c.Name == giverName);
            var reciever = this.party.First(c => c.Name == recieverName);

            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, reciever);

            return String.Format($"{giverName} gave {recieverName} {itemName}.");
        }

        public string GetStats()
        {
            var sorted = this.party
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health)
                .ToList();

            var sb = new StringBuilder();

            foreach (var character in sorted)
            {
                sb.AppendLine(character.ToString());
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var recieverName = args[1];

            if (!this.party.Any(c => c.Name == attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            if (!this.party.Any(c => c.Name == recieverName))
            {
                throw new ArgumentException($"Character {recieverName} not found!");
            }

            var attacker = this.party.First(c => c.Name == attackerName);
            var reciever = this.party.First(c => c.Name == recieverName);

            if (!(attacker is IAttackable))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var attackerAsWarrior = (Warrior)attacker;

            attackerAsWarrior.Attack(reciever);

            var sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {recieverName} for {attacker.AbilityPoints} hit points! {recieverName} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armor}/{reciever.BaseArmor} AP left!");

            if (!reciever.IsAlive)
            {
                sb.AppendLine($"{reciever.Name} is dead!");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healRecieverName = args[1];

            if (!this.party.Any(c => c.Name == healerName))
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            if (!this.party.Any(c => c.Name == healRecieverName))
            {
                throw new ArgumentException($"Character {healRecieverName} not found!");
            }

            var healer = this.party.First(c => c.Name == healerName);
            var reciever = this.party.First(c => c.Name == healRecieverName);

            if (!(healer is IHealable))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            var healerAsCleric = (Cleric)healer;

            healerAsCleric.Heal(reciever);

            return String.Format($"{healer.Name} heals {reciever.Name} for {healer.AbilityPoints}! {reciever.Name} has {reciever.Health} health now!");
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = this.party
                .Where(c => c.IsAlive == true)
                .ToList();

            var sb = new StringBuilder();

            foreach (var aliveCharacter in aliveCharacters)
            {
                var healthBeforeRest = aliveCharacter.Health;
                aliveCharacter.Rest();

                sb.AppendLine(String.Format(OutputMessages.RestMessage, aliveCharacter.Name, healthBeforeRest, aliveCharacter.Health));
            }

            if (aliveCharacters.Count == 1 || aliveCharacters.Count == 0)
            {
                lastSurvivorRounds++;
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRounds > 1)
            {
                return true;
            }

            return false;
        }
    }
}
