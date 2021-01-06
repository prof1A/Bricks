using Bricks.Exceptions;
using Bricks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks.Classes
{
    class HardMenu : IMenu
    {
        Game game;

        int repeat = 0;

        Random random = new Random();

        public bool EndOfGame { get; set; }

        public HardMenu(Game game)
        {
            this.game = game;
        }
        void ShowField()
        {
            for (int i = 0; i < game.CurrentField.Bricks.Length; i++)
            {
                if (i % game.CurrentField.Width == 0 & i != 0)
                    Console.WriteLine();
                Console.Write(game.CurrentField.Bricks[i] + " ");
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

            game.CreateField(height, width);

            Console.Clear();

            while (!Win(game.CurrentField.Bricks))
            {
                if (repeat == value)
                {
                    game.CreateField(height, width);
                    repeat = 0;
                    value = random.Next(1, 10);
                }

                ShowField();

                Console.Write("Input of number:");

                string number = Console.ReadLine();

                InputNumber(game.CurrentField.Bricks, number);

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

        void InputNumber(Brick[] bricks, string number)
        {
            
            string[] field = new string[bricks.Length];

            for (int i = 0; i < bricks.Length; i++)
                field[i] = bricks[i].Symbol;

            if (!Array.Exists(field, v => v == number))
                throw new NumberException("Incorrect number!");
            else
            {
                int index_number = Array.IndexOf(field, number);

                int index_star = Array.IndexOf(field, "*");

                string temp = null;

                if ((index_star + 1) % game.CurrentField.Width == 1)
                {
                    bool b = (index_number == index_star + 1 || index_number == index_star + game.CurrentField.Width || index_number == index_star - game.CurrentField.Width);
                    if (b)
                    {
                        temp = field[index_number];

                        field[index_number] = field[index_star];

                        field[index_star] = temp;
                    }
                }
                else if ((index_star + 1) % game.CurrentField.Width == 0)
                {
                    bool b = (index_number == index_star - 1 || index_number == index_star + game.CurrentField.Width || index_number == index_star - game.CurrentField.Width);
                    if (b)
                    {
                        temp = field[index_number];

                        field[index_number] = field[index_star];

                        field[index_star] = temp;
                    }
                }
                else if (index_number == index_star - game.CurrentField.Width || index_number == index_star + game.CurrentField.Width || index_number == index_star - 1 || index_number == index_star + 1)
                {
                    temp = field[index_number];

                    field[index_number] = field[index_star];

                    field[index_star] = temp;
                }

                game.CurrentField.Bricks = null;

                game.CurrentField.Bricks = new Brick[field.Length];

                for (int i = 0; i < field.Length; i++)
                    game.CurrentField.Bricks[i] = new Brick(field[i]);
            }
        }
    }
}
