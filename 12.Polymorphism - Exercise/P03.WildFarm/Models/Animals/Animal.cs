using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Models.Food;

namespace P03.WildFarm.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        protected abstract double WeightAddOnMultiplier { get; }

        protected abstract List<Type> PrefferedFoods { get; }

        protected string Name { get; set; }

        protected double Weight { get; set; }

        protected int FoodEaten { get; set; }

        public abstract string ProduceSound();

        public void Feed(Food.Food food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightAddOnMultiplier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
