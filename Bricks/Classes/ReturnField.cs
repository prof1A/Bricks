using Bricks.Interfaces;

namespace Bricks.Classes
{
    class ReturnField : ICommand
    {
        IMenuFunction menuFunction;

        Game game;

        Brick[] bricks;

        public ReturnField(IMenuFunction menuFunction, Game game, Brick[] bricks)
        {
            this.menuFunction = menuFunction;

            this.game = game;

            this.bricks = bricks;
        }
        public void Execute()
        {
            menuFunction.RestoreField(game, bricks);
        }
    }
}
