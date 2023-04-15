using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.Recipes;

namespace CoffeeMachine.UI
{
    interface IUI
    {

        void ShowInfo(string text);
        void Ready(string text);

        void Error(string text);
        void Error();
        int ChooseRecipe();

        void Start();
        List<Coffee> Take();
    }
}
