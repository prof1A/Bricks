using Bricks.Interfaces;

namespace Bricks.Classes
{
    class InputDatesOfField : ICommand
    {
        readonly IMenuFunction menuFunction;

        readonly Game game;

        readonly int height;

        readonly int width;

        public InputDatesOfField(IMenuFunction menuFunction, Game game, int height, int width)
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
    }
}