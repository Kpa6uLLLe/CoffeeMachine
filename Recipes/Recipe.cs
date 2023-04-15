using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Recipes
{
    class Recipe 
    {
        public string Name { get; }
        public float Milk { get; }

        public float Water { get; }

        public float Grains { get; }

        public Recipe(float milk, float water, float grains, string name)
        {
            this.Milk = milk;
            this.Water = water;
            this.Grains = grains;
            this.Name = name;
        }
        public override string ToString()
        {
            return $"#{Name}#Milk: {Milk}, Water: {Water}, Grains: {Grains}";
        }
    }
}
