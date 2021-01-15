using Bricks.Interfaces;

namespace Bricks.Classes
{
    class SaveField : ICommand
    {
        IMenuFunction menuFunction;

        Brick[] bricks;

        public SaveField(IMenuFunction menuFunction, Brick[]bricks)
        {
            this.menuFunction = menuFunction;

            this.bricks = bricks;
        }
        public void Execute()
        {
            menuFunction.SaveField(bricks);
        }
    }
}
