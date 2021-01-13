using Bricks.Interfaces;
using System;

namespace Bricks.Classes
{
    class InputDatesOfField : ICommand
    {
        MenuFuction menuFuction;
        int height;
        int width;
        public InputDatesOfField(MenuFuction menuFuction,int height,int width)
        {
            this.menuFuction = menuFuction;
            this.height = height;
            this.width = width;
        }

        public void Execute()
        {
            menuFuction.CreateField(new Game(), height, width);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}