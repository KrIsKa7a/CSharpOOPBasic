using P03.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override double WeightAddOnMultiplier => 0.30;

        protected override List<Type> PrefferedFoods =>
            new List<Type> { typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
