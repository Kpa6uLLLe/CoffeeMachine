using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Recipes
{
    class RecipeList
    {
        private List<Recipe> recipes;

        public RecipeList(List<Recipe> recipes)
        {
            this.recipes = recipes;
        }
        public RecipeList()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach(Recipe recipe in recipes)
            {
                sb.Append($"[{i}]").Append(recipe.ToString()).Append("\n");
                i++;
            }
            return sb.ToString();
        }

        public Recipe GetByIndex(int i)
        {
            return recipes[i];
        }
        public int Length()
        {
            return recipes.Count;
        }
    }
}
