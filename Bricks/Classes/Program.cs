using System;

namespace Bricks.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choise the level of game");

            Console.WriteLine("1.Eazy");

            Console.WriteLine("2.Hard");

            Console.Write("Your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Invoker invoker = new Invoker();

            invoker.SetCommand(new InputTheLevelOfGame(choice));

            invoker.Run();
        }
    }
}