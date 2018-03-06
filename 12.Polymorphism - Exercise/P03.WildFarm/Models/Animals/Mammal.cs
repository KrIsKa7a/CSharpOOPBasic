using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion { get; set; }
    }
}
