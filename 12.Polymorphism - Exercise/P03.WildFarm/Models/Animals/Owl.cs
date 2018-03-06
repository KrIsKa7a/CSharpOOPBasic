using P03.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        protected override double WeightAddOnMultiplier => 0.25;

        protected override List<Type> PrefferedFoods => 
            new List<Type> { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
