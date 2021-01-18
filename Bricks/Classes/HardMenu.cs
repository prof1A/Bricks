using Bricks.Exceptions;
using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class HardMenu : IMenu
    {
        readonly Game game;

        IMenuFunction menuFunction = new MenuFunction();

        public HardMenu(Game game)
        {
            this.game = game;
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

            while (true)
            {
                try
                {
                    if (menuFunction.Win(game.CurrentField.Bricks))
                    {
                        menuFunction.ShowField(game.CurrentField);

                        break;
                    }
                    while (!menuFunction.Win(game.CurrentField.Bricks))
                    {
                        if (repeat == value)
                        {
                            menuFunction.CreateField(game, height, width);

                            repeat = 0;

                            value = random.Next(1, 10);
                        }

                        menuFunction.ShowField(game.CurrentField);

                        Console.WriteLine("1.Input number");

                        Console.WriteLine("2.Save");

                        Console.WriteLine("3.Restore");

                        Console.Write("Your choice:");

                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:

                                Console.Write("Input of number:");

                                string number = Console.ReadLine();

                                invoker.SetCommand(new InputNumber(menuFunction, game, number));

                                Console.Clear();

                                break;

                            case 2:

                                invoker.SetCommand(new SaveField(menuFunction, game.CurrentField.Bricks));

                                break;

                            case 3:

                                invoker.SetCommand(new ReturnField(menuFunction, game, game.CurrentField.Bricks));

                                break;
                        }

                        invoker.Run();
                        repeat++;
                        break;
                    }
                }
                catch (NumberException ex)
                {
                    Console.Clear();

                    Console.WriteLine(ex.Message);
                }
            } 

            Console.WriteLine("Победа");
        }
    }
}
