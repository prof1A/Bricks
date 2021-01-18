using Bricks.Exceptions;
using Bricks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bricks.Classes
{
    public class MenuFunction : IMenuFunction
    {

        GameHistory gameHistory = new GameHistory();
        public void ShowField(Field field)
        {
            for (int i = 0; i < field.Bricks.Length; i++)
            {
                if (i % field.Width == 0 & i != 0)
                    Console.WriteLine();

                Console.Write(field.Bricks[i] + "\t");
            }
            Console.WriteLine("\n\n");
        }
        public void CreateField(Game game, int height, int width)
        {

            Random random = new Random();

            List<int> numbers = new List<int>();

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


            Brick[] bricks = numbers.Select(x=> new Brick(x.ToString())).ToArray();

            var rx = random.Next(1, height * width);

            var list = bricks.ToList();
            list.Insert(rx, new Brick("*"));

            bricks = list.ToArray();

            Field field = new Field { Height = height, Width = width, Bricks = bricks };

            game.CurrentField = field;
        }

        public bool Win(Brick[] bricks)
        {
            var sorted = bricks
                .Select(x => x.Symbol)
                .OrderBy(x => x);

            return sorted.SequenceEqual(bricks.Select(x => x.Symbol));
        }

        public void InputNumber(Game game, string number)
        {

            string[] field = game.CurrentField.Bricks.Select(x=>x.Symbol).ToArray();

            if (!Array.Exists(field, v => v == number))
            {
                throw new NumberException("Неправильное число");
            }
            
            int index_number = Array.IndexOf(field, number);

            int index_star = Array.IndexOf(field, "*");



            List<int> availableIndexes = new List<int>();

            availableIndexes.Add(index_star + 1);
            availableIndexes.Add(index_star - 1);
            availableIndexes.Add(index_star + game.CurrentField.Width);
            availableIndexes.Add(index_star - game.CurrentField.Width);

            string temp = null;

            foreach (var num in availableIndexes)
            {
                if (num == index_number)
                {
                    temp = field[index_number];

                    field[index_number] = field[index_star];

                    field[index_star] = temp;
                    break;
                }
            }


            game.CurrentField.Bricks = new Brick[field.Length];

            for (int i = 0; i < field.Length; i++)
                game.CurrentField.Bricks[i] = new Brick(field[i]);
        }

        public void SaveField(Brick[] bricks)
        {
            gameHistory.History.Push(bricks);
        }

        public Brick[] RestoreField(Game game, Brick[] bricks)
        {
            return game.CurrentField.Bricks = gameHistory.History.Pop();
        }

        public bool Contains(List<int> vs, int value)
        {
            return vs.Contains(value);
        }
    }
}