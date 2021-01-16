using Bricks.Interfaces;

namespace Bricks.Classes
{
    class InputNumber : ICommand
    {
        readonly IMenuFunction menuFuction;

        readonly Game game;

        readonly string number;

        public InputNumber(IMenuFunction menuFuction,Game game, string number)
        {
            this.menuFuction = menuFuction;

            this.game = game;

            this.number = number;
        }
        public void Execute()
        {
            menuFuction.InputNumber(game, number);
        }
    }
}
