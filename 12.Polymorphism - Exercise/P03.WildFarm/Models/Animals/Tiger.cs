using P03.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        protected override double WeightAddOnMultiplier => 1.0;

        protected override List<Type> PrefferedFoods =>
            new List<Type> { typeof(Meat) };
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
