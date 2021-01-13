using System;
using Bricks.Exceptions;
using Bricks.Interfaces;

namespace Bricks.Classes
{
    class HardMenu : IMenu
    {
        Game game;

        IMenuFunction menuFunction = new MenuFunction();

        public HardMenu(Game game)
        {
            this.game = game;
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
            Invoker invoker = new Invoker();

            Random random = new Random();

            int repeat = 0;

            int value = random.Next(1, 10);

            Console.Write("Input of height:");

            int height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input of width:");

            int width = Convert.ToInt32(Console.ReadLine());

            invoker.SetCommand(new InputDatesOfField(menuFunction, game, height, width));

            invoker.Run();

            Console.Clear();

            do
            {
                try
                { 
                    if (menuFunction.Win(game.CurrentField.Bricks))
                    {
                        menuFunction.ShowField(game.CurrentField);
                        break;
                    }
                    else
                    {
                        while (!menuFunction.Win(game.CurrentField.Bricks))
                        {
                            if (repeat == value)
                            {
                                menuFunction.CreateField(game, height, width);

                                repeat = 0;

                                value = random.Next(1, 10);
                            }

                            menuFunction.ShowField(game.CurrentField);

                            Console.Write("Input of number or save:");

                            string answer = Console.ReadLine();

                            invoker.SetCommand(new InputNumber(menuFunction,game, answer));

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
