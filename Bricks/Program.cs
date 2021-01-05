using Bricks.Classes;
using Bricks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu;
            List<Type> _menues = new List<Type>()
            {
                typeof(EazyMenu),
                typeof(HardMenu)
            };
            Console.WriteLine("Choise level of game");
            Console.WriteLine("1.Eazy");
            Console.WriteLine("2.Hard");
            Console.Write("Your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                menu = new EazyMenu(new Game());
                menu.GameProcess();
            }
            if (choice == 2)
            {
                menu = new HardMenu(new Game());
                menu.GameProcess();
            }


        }
    }
}
