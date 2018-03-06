using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Models.Food;

namespace P03.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        protected override double WeightAddOnMultiplier => 0.35;

        protected override List<Type> PrefferedFoods => new List<Type> { typeof(Vegetable), typeof(Fruit), typeof(Seeds), typeof(Meat) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
