using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Static_data
{
    public static class OutputMessages
    {
        public const string NotAliveCharacter = "Must be alive to perform this action!";

        public const string FullBag = "Bag is full!";

        public const string EmptyBag = "Bag is empty!";

        public const string NoSuchItemInTheBag = "No item with name {0} in bag!";

        public const string EmptyName = "Name cannot be null or whitespace!";

        public const string AttackSelf = "Cannot attack self!";

        public const string FriendlyFire = "Friendly fire! Both characters are from {0} faction!";

        public const string HealingEnemy = "Cannot heal enemy character!";

        public const string InvalidFaction = "Invalid faction \"{0}\"!";

        public const string InvalidCharacterType = "Invalid character type \"{0}\"!";

        public const string SuccessfullyJoinedTheParty = "{0} joined the party!";

        public const string InvalidItemType = "Invalid item \"{0}\"!";

        public const string SuccessfullyAddedItem = "{0} added to pool.";

        public const string InexistingCharacterInThePool = "Character {0} not found!";

        public const string EmptyItemPool = "No items left in pool!";

        public const string ItemAddedToCharacterBag = "{0} picked up {1}!";

        public const string SuccessfullyUsedItemOnSelf = "{0} used {1}.";

        public const string SuccessfullyUsedItemOnOtherCharacter = "{0} used {1} on {2}.";

        public const string SuccessfullyGivenItemOnOtherCharacter = "{0} gave {1} {2}.";

        public const string AttackerCannotAttack = "{0} cannot attack!";

        public const string HealerCannotHeal = "{0} cannot heal!";

        public const string SuccessfullHealing = "{0} heals {1} for {2}! {1} has {3} health now!";

        public const string RestMessage = "{0} rests ({1} => {2})";
    }
}
