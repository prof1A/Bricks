using System;
using Bricks.Interfaces;

namespace Bricks.Classes
{
    class InputDatesOfField : ICommand
    {
        IMenuFunction menuFunction;

        Game game;

        int height;

        int width;

        public InputDatesOfField(IMenuFunction menuFunction,Game game,int height,int width)
        {
            this.menuFunction = menuFunction;

            this.game = game;

            this.height = height;

            this.width = width;
        }

        public void Execute()
        {
            menuFunction.CreateField(game, height, width);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}