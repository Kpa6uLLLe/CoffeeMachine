using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.UI;
using CoffeeMachine.Recipes;
namespace CoffeeMachine
{
    class Machine
    {
        public delegate void ErrorHandler();
        public delegate void ErrorTextHandler(string text);
        public delegate void CoffeeReadyHandler(string text);
        public event ErrorHandler Error;
        public event CoffeeReadyHandler Ready;
        public event ErrorTextHandler ErrorText;
        public readonly RecipeList recipeList;
        private ResourceContainer milk, grains, water;
        private Recipe currentRecipe;
        private readonly float defaultMaxVolume = 100;
        public Machine(RecipeList recipeList)
        {
            this.recipeList = recipeList;
            this.milk = new ResourceContainer(defaultMaxVolume);
            this.water = new ResourceContainer(defaultMaxVolume);
            this.grains = new ResourceContainer(defaultMaxVolume);
        }
        public Machine(float milk, float water, float grains, RecipeList recipeList)
        {
            this.recipeList = recipeList;
            this.milk = new ResourceContainer(defaultMaxVolume,milk);
            this.water = new ResourceContainer(defaultMaxVolume, water);
            this.grains = new ResourceContainer(defaultMaxVolume, grains);
        }
        public Machine(ResourceContainer milk, ResourceContainer water, ResourceContainer grains, RecipeList recipeList)
        {
            this.recipeList = recipeList;
            this.milk = milk;
            this.water = water;
            this.grains = grains;
        }
        public void GetRecipeFromUI(int i)
        {
            currentRecipe = recipeList.GetByIndex(i);
        }
        public void AddResources(float milk, float water, float grains)
        {
            this.milk.Add(milk);
            this.water.Add(water);
            this.grains.Add(grains);
        }
        public Coffee MakeCoffee()
        {
            ResourceContainer milkClone = (ResourceContainer)milk.Clone();
            ResourceContainer waterClone = (ResourceContainer)water.Clone();
            ResourceContainer grainsClone = (ResourceContainer)grains.Clone();
            try
            {
                Coffee coffee = new Coffee();
                milk.Add(currentRecipe.Milk * -1);
                water.Add(currentRecipe.Water * -1);
                grains.Add(currentRecipe.Grains * -1);
                coffee.recipe = currentRecipe;
                Ready($"Your {coffee.recipe.Name} is ready!");
                return coffee;
            }
            catch (NotEnoughResourcesException e)
            {
                milk = milkClone;
                water = waterClone;
                grains = grainsClone;
                ErrorText($"{e.Message}(Not enough resources)");
                throw e;
            }
            catch (Exception e)
            {
                milk = milkClone;
                water = waterClone;
                grains = grainsClone;
                Error();
                throw e;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Hello! I'm a coffee machine.\n");
            sb.Append($"Resources: \nMilk - {milk.ToString()}, Water - {water.ToString()}, Grains - {grains.ToString()}\n");
            sb.Append("Here's the list of recipes.\nType option's number to select it or negative number to exit: \n");
            sb.Append(recipeList.ToString());
            return sb.ToString();
        }
    }
}
