using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        protected double WingSize { get; set; }

        public override string ToString()
        {
            return base.ToString() + 
                $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
