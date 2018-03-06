using P03.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        protected override double WeightAddOnMultiplier => 0.10;

        protected override List<Type> PrefferedFoods => 
            new List<Type> { typeof(Fruit), typeof(Vegetable)};

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
