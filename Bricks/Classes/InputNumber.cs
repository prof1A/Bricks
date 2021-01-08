using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class InputNumber : ICommand
    {
        IMenu menu;
        public InputNumber(IMenu menu)
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
