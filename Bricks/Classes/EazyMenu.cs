using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class EazyMenu : IMenu
    {
        public Game Game { get; set; }
        MenuFuction menuFunction = new MenuFuction();
        public EazyMenu(Game game)
        {
            Game = game;
        }
        void ShowField()
        {
            for (int i = 0; i < Game.CurrentField.Bricks.Length; i++)
            {
                if (i % Game.CurrentField.Width == 0 & i != 0)
                    Console.WriteLine();

                Console.Write(Game.CurrentField.Bricks[i] + " ");
            }
            Console.WriteLine("\n\n");
        }
        public void GameProcess()
        {

            Console.Write("Input of height:");

            int height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input of width:");

            int width = Convert.ToInt32(Console.ReadLine());

            menuFunction.CreateField(Game, height, width);

            Console.Clear();

            if (menuFunction.Win(Game.CurrentField.Bricks))
                menuFunction.ShowField(Game.CurrentField);
            else
            {
                while (!menuFunction.Win(Game.CurrentField.Bricks))
                {
                    menuFunction.ShowField(Game.CurrentField);

                    Console.Write("Input of number:");

                    string number = Console.ReadLine();

                    Invoker invoker = new Invoker();

                    invoker.SetCommand(new InputNumber(menuFunction, number));

                    invoker.Run();

                    Console.Clear();

                }
            }
            Console.WriteLine("Победа!");
        }
    }
}
