using Bricks.Exceptions;
using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class HardMenu : IMenu
    {
        public Game Game { get; set; }

        MenuFuction menuFunction = new MenuFuction();
        public HardMenu(Game game)
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
        bool Win(Brick[] bricks)
        {
            int number = 0;

            string[] new_field = new string[bricks.Length - 1];

            for (int i = 0; i < new_field.Length; i++)
            {
                number++;

                new_field[i] = Convert.ToString(number);
            }

            for (int i = 0; i < new_field.Length; i++)
            {
                if (bricks[i].Symbol != new_field[i])
                    return false;
            }

            return true;
        }
        public void GameProcess()
        {

            Random random = new Random();

            int repeat = 0;

            int value = random.Next(1, 10);

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
                            if (repeat == value)
                            {
                                menuFunction.CreateField(Game, height, width);

                                repeat = 0;

                                value = random.Next(1, 10);
                            }

                            ShowField();

                            Console.Write("Input of number:");

                            string number = Console.ReadLine();

                            Invoker invoker = new Invoker();

                            invoker.SetCommand(new InputNumber(menuFunction, number));

                            invoker.Run();

                            repeat++;

                            Console.Clear();
                        }
                        break;
                    }
                }
                catch(NumberException ex)
                {
                    Console.Clear();

                    Console.WriteLine(ex.Message);
                }
            } while (true);
            Console.WriteLine("Победа");
        }
    }
}
