using Bricks.Exceptions;
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
        public void GameProcess()
        {
            Invoker invoker = new Invoker();

            Console.Write("Input of height:");

            int height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input of width:");

            int width = Convert.ToInt32(Console.ReadLine());

            menuFunction.CreateField(Game, height, width);

            Console.Clear();
            do
            {
                try
                {
                    if (menuFunction.Win(Game.CurrentField.Bricks))
                    {
                        menuFunction.ShowField(Game.CurrentField);
                        break;
                    }
                    else
                    {
                        while (!menuFunction.Win(Game.CurrentField.Bricks))
                        {
                            menuFunction.ShowField(Game.CurrentField);

                            Console.Write("Input of number:");

                            string number = Console.ReadLine();

                            invoker = new Invoker();

                            invoker.SetCommand(new InputNumber(menuFunction, number));

                            invoker.Run();

                            Console.Clear();

                        }

                        break;
                    }
                }
                catch (NumberException ex)
                {
                    Console.Clear();

                    Console.WriteLine(ex.Message);

                }
            }while (true);

            Console.WriteLine("Победа");
        }
    }
}
