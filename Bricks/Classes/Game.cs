using System;
using System.Collections.Generic;

namespace Bricks.Classes
{
    class Game
    {
        public Field CurrentField { get; set; }

        public void CreateField(int height, int width)
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

            CurrentField = new Field { Height = height, Width = width, Bricks = bricks };
        }
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
