using CoffeeMachine.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.UI
{
    class ConsoleUI : IUI
    {
        public delegate Coffee Handler();
        public Handler Started;
        private Machine machine;
        public List<Coffee> orders = new List<Coffee>();
        public ConsoleUI(Machine machine)
        {
            this.machine = machine;
            Started += machine.MakeCoffee;
            machine.Error += Error;
            machine.ErrorText += Error;
            machine.Ready += Ready;
            int i = 0;
            while (true)
            {
                ShowInfo(machine.ToString());
                try
                {
                    i = ChooseRecipe();
                }
                catch(Exception e)
                {
                    Console.Clear();
                    continue;
                }
                if (i < 0)
                    break;
                machine.GetRecipeFromUI(i);
                Start();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            Console.Clear();
            Console.WriteLine("You've ordered");
            foreach (Coffee coffee in orders)
            {
                Console.WriteLine(coffee.ToString());
            }
            Console.ReadLine();
        }
        public int ChooseRecipe()
        {
            int response;
            response = Int32.Parse(Console.ReadLine());
            return response;
        }

        public void Error(string text)
        {
            Console.WriteLine($"#ERROR: {text}");
        }

        public void Error()
        {
            Console.WriteLine("Unknown problem has occured.");
        }

        public void Start()
        {
            orders.Add(machine.MakeCoffee());
        }

        public void Ready(string text)
        {
            Console.WriteLine(text);
        }

        public void ShowInfo(string text)
        {
            Console.WriteLine(text);
        }

        public List<Coffee> Take()
        {
            return orders;
        }
    }
}
