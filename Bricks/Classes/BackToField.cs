using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class BackToField : ICommand
    {
        IMenu menu;
        public BackToField(IMenu menu)
        {
            this.menu = menu;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
