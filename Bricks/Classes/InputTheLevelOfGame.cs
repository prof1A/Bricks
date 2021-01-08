using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class InputTheLevelOfGame : ICommand
    {
        IMenu menu;

        public InputTheLevelOfGame(IMenu menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            
        }
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
