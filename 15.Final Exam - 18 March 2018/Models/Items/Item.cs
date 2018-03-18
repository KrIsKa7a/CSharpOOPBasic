using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Static_data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.NotAliveCharacter);
            }
        }
    }
}
