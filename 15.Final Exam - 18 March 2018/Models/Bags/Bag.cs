using DungeonsAndCodeWizards.Models.Items;
using DungeonsAndCodeWizards.Static_data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        
        public int Capacity { get; }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items;
            }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(OutputMessages.FullBag);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(OutputMessages.EmptyBag);
            }

            if (!this.Items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException(String.Format(OutputMessages.NoSuchItemInTheBag, name));
            }

            var item = this.Items.First(i => i.GetType().Name == name);

            this.items.Remove(item);

            return item;
        }
    }
}
