using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.Recipes;
namespace CoffeeMachine
{
    class Coffee
    {

        public Recipe recipe;
        public override string ToString()
        {
            return recipe.ToString() + "\n";
        }
    }
}
