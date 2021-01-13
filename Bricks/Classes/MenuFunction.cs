using System;
using System.Collections.Generic;
using Bricks.Exceptions;
using Bricks.Interfaces;

namespace Bricks.Classes
{
    class MenuFunction : IMenuFunction
    {
        public void ShowField(Field field)
        {
            for (int i = 0; i < field.Bricks.Length; i++)
            {
                if (i % field.Width == 0 & i != 0)
                    Console.WriteLine();
                Console.Write(field.Bricks[i] + " ");
            }
            Console.WriteLine("\n\n");
        }
        public void CreateField(Game game, int height, int width)
        {

            Random random = new Random();

            List<int> numbers = new List<int>();

            List<string> vs = new List<string>();

            int value = 0;

            for (int i = 0; i < (height * width) - 1; i++)
            {
                int next = 0;

                while (true)
                {
                    next = random.Next(1, height * width);

                    if (!Contains(numbers, next)) break;
                }

                numbers.Add(next);
            }

            for (int i = 0; i < numbers.Count; i++)
                vs.Add(numbers[i].ToString());

            value = random.Next(0, height * width);

            vs.Insert(value, "*");

            string[] numbers_string = vs.ToArray();

            Brick[] bricks = new Brick[numbers_string.Length];

            for (int i = 0; i < bricks.Length; i++)
                bricks[i] = new Brick(numbers_string[i]);

            Field field = new Field { Height = height, Width = width, Bricks = bricks };

            game.CurrentField = field;
        }
        public bool Win(Brick[] bricks)
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

        public void InputNumber(Game game, string number)
        {

            string[] field = new string[game.CurrentField.Bricks.Length];

            for (int i = 0; i < game.CurrentField.Bricks.Length; i++)
                field[i] = game.CurrentField.Bricks[i].Symbol;

            if (!Array.Exists(field, v => v == number))
            {
                throw new NumberException("Неправильное число");
            }
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
        public Field SaveField(Field field)
        {
            return field;
        }
        //public void RestoreField(Game game,Field field)
        //{
        //    game.CurrentField = field;
        //}
        static bool Contains(List<int> vs, int value)
        {
            for (int i = 0; i < vs.Count; i++)
            {
                if (vs[i] == value) return true;
            }
            return false;
        }
    }
}