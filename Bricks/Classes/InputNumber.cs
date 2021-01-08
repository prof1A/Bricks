using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class InputNumber : ICommand
    {
        IMenu menu;

        string number;
        public InputNumber(IMenu menu,string number)
        {
            this.menu = menu;

            this.number = number;
        }
        public void Execute()
        {
            menu.InputNumber(menu.Game.CurrentField.Bricks, number);
        }
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
