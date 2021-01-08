using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class HardMenu : IMenu
    {
        public Game Game { get; set; }
        public bool EndOfGame { get; set; }

        int repeat = 0;

        Random random = new Random();

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
        public void GameProcess()
        {
            int value = random.Next(1,10);

            Console.Write("Input of height:");

            int height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input of width:");

            int width = Convert.ToInt32(Console.ReadLine());

            Game.CreateField(height, width);

            Console.Clear();

            while (!Win(Game.CurrentField.Bricks))
            {
                if (repeat == value)
                {
                    Game.CreateField(height, width);
                    repeat = 0;
                    value = random.Next(1, 10);
                }

                ShowField();

                Console.Write("Input of number:");

                string number = Console.ReadLine();

                InputNumber(Game.CurrentField.Bricks, number);

                repeat++;

                Console.Clear();

            }

            Console.WriteLine("Пошел нахуй");

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
            
            EndOfGame = true;

            return true;
        }

        public void InputNumber(Brick[] bricks, string number)
        {
            
            string[] field = new string[bricks.Length];

            for (int i = 0; i < bricks.Length; i++)
                field[i] = bricks[i].Symbol;

            if (!Array.Exists(field, v => v == number))
            {
               
            }
            else
            {
                int index_number = Array.IndexOf(field, number);

                int index_star = Array.IndexOf(field, "*");

                string temp = null;

                if ((index_star + 1) % Game.CurrentField.Width == 1)
                {
                    bool b = (index_number == index_star + 1 || index_number == index_star + Game.CurrentField.Width || index_number == index_star - Game.CurrentField.Width);
                    if (b)
                    {
                        temp = field[index_number];

                        field[index_number] = field[index_star];

                        field[index_star] = temp;
                    }
                }
                else if ((index_star + 1) % Game.CurrentField.Width == 0)
                {
                    bool b = (index_number == index_star - 1 || index_number == index_star + Game.CurrentField.Width || index_number == index_star - Game.CurrentField.Width);
                    if (b)
                    {
                        temp = field[index_number];

                        field[index_number] = field[index_star];

                        field[index_star] = temp;
                    }
                }
                else if (index_number == index_star - Game.CurrentField.Width || index_number == index_star + Game.CurrentField.Width || index_number == index_star - 1 || index_number == index_star + 1)
                {
                    temp = field[index_number];

                    field[index_number] = field[index_star];

                    field[index_star] = temp;
                }

                Game.CurrentField.Bricks = null;

                Game.CurrentField.Bricks = new Brick[field.Length];

                for (int i = 0; i < field.Length; i++)
                    Game.CurrentField.Bricks[i] = new Brick(field[i]);
            }
        }
    }
}
