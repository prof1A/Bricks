using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class InputNumber : ICommand
    {
        MenuFuction menuFuction;

        string number;
        public InputNumber(MenuFuction menuFuction, string number)
        {
            this.menuFuction = menuFuction;

            this.number = number;
        }
        public void Execute()
        {
            menuFuction.InputNumber(menuFuction.Game, number);
        }
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
