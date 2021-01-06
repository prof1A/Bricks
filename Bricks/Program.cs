using Bricks.Classes;
using Bricks.Exceptions;
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
            Console.WriteLine("Choise level of game");
            Console.WriteLine("1.Eazy");
            Console.WriteLine("2.Hard");
            Console.Write("Your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            bool endOfGame = false;
            do
            {
                try
                {
                    if (choice == 1)
                    {
                        menu = new EazyMenu(new Game());
                        menu.GameProcess();
                        endOfGame = menu.EndOfGame;
                    }
                    else if (choice == 2)
                    {
                        menu = new HardMenu(new Game());
                        menu.GameProcess();
                        endOfGame = menu.EndOfGame;
                    }
                }
                catch (NumberException ne)
                {
                    Console.WriteLine(ne.Message);
                }
                catch(FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            } while(!endOfGame);
            Console.WriteLine("sdaads");

        }
    }
}
