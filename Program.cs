using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.UI;
using CoffeeMachine.Recipes;
namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> list = new List<Recipe>();
            list.Add(new Recipe(1, 0, 0, "Milk Drop"));
            list.Add(new Recipe(0, 1, 0, "Water Drop"));
            list.Add(new Recipe(20, 10, 20, "Latte S"));
            list.Add(new Recipe(40, 10, 0, "Milk&Water"));
            list.Add(new Recipe(30, 15, 40, "Latte M"));
            list.Add(new Recipe(49, 20, 55, "Latte XXL"));
            RecipeList recipeList = new RecipeList(list);
            Machine machine = new Machine(recipeList);
            machine.AddResources(99, 99, 99);
            IUI ui = new ConsoleUI(machine);
            List<Coffee> myOrders = ui.Take();
            
        }
    }
}
