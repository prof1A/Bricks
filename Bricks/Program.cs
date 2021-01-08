using Bricks.Classes; 
using Bricks.Interfaces;
using System;

namespace Bricks
{
    class Program
    {
        static void Main(string[] args)
        {

            IMenu[] menu = new IMenu[] { new EazyMenu(new Game()), new HardMenu(new Game()) };

            Console.WriteLine("Choise level of game");

            Console.WriteLine("1.Eazy");
            
            Console.WriteLine("2.Hard");

            Console.Write("Your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            bool endOfGame = false;

            do
            {
                menu[choice -1].GameProcess();

                endOfGame = menu[choice - 1].EndOfGame;
                    
            } 
            while(!endOfGame);

        }
    }
}
