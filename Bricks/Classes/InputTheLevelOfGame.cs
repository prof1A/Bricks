using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class InputTheLevelOfGame : ICommand
    {
        IMenu[] menu = new IMenu[] { new EazyMenu(new Game()), new HardMenu(new Game()) };

        int choice;
        public InputTheLevelOfGame(int choice)
        {
            this.choice = choice;
        }
        public void Execute()
        {
            menu[choice - 1].GameProcess();
        }
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
